using NetMQ;
using NetMQ.Sockets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Thrift.Protocols;
using Thrift.Transports;
using Thrift.Transports.Client;

namespace Ruyi.Layer0.ZeroMQ
{
    public class SubscribeClient : ISubscribeClient
    {
        SubscriberSocket socket;
        bool disposing = false;
        // Not used but useful for debuging
#pragma warning disable 414
        string serverUri = null;
#pragma warning restore 414
        List<string> topics = new List<string>();

        Task receivingThread = null;
        CancellationTokenSource cts;

        Dictionary<string, Delegate> MsgHandlers = new Dictionary<string, Delegate>();

        public static SubscribeClient CreateInstance(string serverUri)
        {
            SubscribeClient ret = new SubscribeClient
            {
                socket = new SubscriberSocket(),
                serverUri = serverUri,
                disposing = false
            };
            ret.socket.Connect(serverUri);
            return ret;
        }

        private SubscribeClient()
        {
        }

        public void Subscribe(string topic)
        {
            if (string.IsNullOrEmpty(topic) || topics.Contains(topic))
                return;

            topics.Add(topic);
            socket.Subscribe(topic);
            if (topics.Count > 0 && receivingThread == null)
            {
                cts = new CancellationTokenSource();
                receivingThread = Task.Run(async () =>
                {
                    while (!cts.IsCancellationRequested && await Receive()) ;
                }, cts.Token);
            }
        }

        public void Unsubscribe(string topic)
        {
            if (!topics.Contains(topic))
                return;

            topics.Remove(topic);
            socket.Unsubscribe(topic);
        }

        public void AddGenericMessageHandler(string typeName, MessageHandler<TBase> mh)
        {
            if (mh == null)
                return;

            string tp = typeName;
            if (!MsgHandlers.ContainsKey(tp))
                MsgHandlers.Add(tp, mh);
            else
                MsgHandlers[tp] = Delegate.Combine(MsgHandlers[tp], mh);
        }

        public void RemoveGenericMessageHandler(string typeName, MessageHandler<TBase> mh)
        {
            string tp = typeName;
            if (MsgHandlers.ContainsKey(tp))
                MsgHandlers[tp] = Delegate.Remove(MsgHandlers[tp], mh);
        }

        public void AddMessageHandler<T>(MessageHandler<T> mh) where T : TBase
        {
            if (mh == null)
                return;

            string tp = typeof(T).ToString();
            if (!MsgHandlers.ContainsKey(tp))
                MsgHandlers.Add(tp, mh);
            else
                MsgHandlers[tp] = Delegate.Combine(MsgHandlers[tp], mh);
        }

        public void RemoveMessageHandler<T>(MessageHandler<T> mh) where T : TBase
        {
            string tp = typeof(T).ToString();
            if (MsgHandlers.ContainsKey(tp))
                MsgHandlers[tp] = Delegate.Remove(MsgHandlers[tp], mh);
        }

        void Log(string message, Logging.LogLevel level)
        {
            Logging.Logger.Log(message, level: level, source: nameof(SubscribeClient), category: Logging.MessageCategory.Subscriber);
        }

        const int ReceiveTimeoutMs = 250;
        static readonly TimeSpan ReceiveTimeout = TimeSpan.FromMilliseconds(ReceiveTimeoutMs);

        async Task<bool> Receive()
        {
            try
            {
                NetMQMessage msg = null;
                // NOTE:
                // After switching to async IO, when we close the socket in Dispose() the ReceiveMultipartMessage() wasn't returning.
                // So, we TryReceive() with a timeout.  If it times out the receive loop will check if we retry or exit.
                // If we get an async-friendly version of NetMQ (or switch transports) we can probably go back to regular Receive().
                if (socket.TryReceiveMultipartMessage(ReceiveTimeout, ref msg))
                {
                    if (msg == null || ZeroMQ.PubSubUtil.IsStoppingMessage(msg))
                    {
                        PublisherLogger.Info("stopped by stpping message!");
                        return false;
                    }

                    var topic = msg[0].ConvertToString();
                    var msgType = msg[1].ConvertToString();
                    if (MsgHandlers.TryGetValue(msgType, out Delegate mh))
                    {
                        var respBytes = msg[2].Buffer;
                        using (var proto = ThriftUtil.CreateReadProtocol(respBytes))
                        {
                            Type t = GeneratedTypeCache.GetType(msgType);
                            if (t == null)
                                throw new TargetInvocationException(new Exception("can't get type for: " + msgType));
                            TBase ret = Activator.CreateInstance(t) as TBase;
                            await ret.ReadAsync(proto, cts.Token);
                            mh.DynamicInvoke(topic, ret);
                        }
                    }
                    return true;
                }
                else
                {
                    // Receive timed out.  Return true so receive loop can check if we should exit or try again.
                    return true;
                }
            }
            catch (Exception e)
            {
                if (e is TargetInvocationException ee)
                {
                    Log($"invoke exception: {(ee).InnerException.Message} \n {ee.InnerException.StackTrace}", Logging.LogLevel.Warn);
                    return true;
                }
                if (e is TerminatingException)
                {
                    Log($"terminated: {e.Message}", Logging.LogLevel.Info);
                    return false;
                }
                else
                {
                    if (disposing)
                    {
                        Log("disposing exception: " + e.Message, Logging.LogLevel.Info);
                    }
                    else
                    {
                        Log($"receive exception: {e.Message} \n {e.StackTrace}", Logging.LogLevel.Error);
                    }
                    
                    return false;
                }
            }
        }

#region IDisposable
        public void Dispose()
        {
            disposing = true;
            MsgHandlers.Clear();

            // Stop the receving thread
            try
            {
                if (receivingThread != null)
                {
                    cts.Cancel();
                    receivingThread.Wait(ReceiveTimeoutMs + 50);
                    receivingThread = null;
                }
            }
            catch
            {
                Log("receiving thread aborted", Logging.LogLevel.Info);
            }

            // Unsubscribe from all topics and release socket.
            // If receiving thread is still running when we Dispose() the socket it gets exception we catch and exit
            if (socket != null)
            {
                for (int i = 0; i < topics.Count; i++)
                {
                    try
                    {
                        socket.Unsubscribe(topics[i]);
                    }
                    catch (Exception e)
                    {
                        var level = e is TerminatingException ? Logging.LogLevel.Info : Logging.LogLevel.Error;
                        Log("terminated: " + e.Message, level);
                    }
                }

                try
                {
                    socket.Dispose();
                    socket = null;
                }
                catch
                {
                    Log("socket dispose exception", Logging.LogLevel.Info);
                }
            }

            
        }
    }
#endregion
}
