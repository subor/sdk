using NNanomsg;
using NNanomsg.Protocols;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Thrift.Protocols;
using Thrift.Transports;
using Thrift.Transports.Client;

namespace Ruyi.Layer0
{
    public class PubSubSink : IDisposable
    {
        public const char ThreadNameToken = '|';

        public delegate void MessageHandler<T>(string topic, T msg) where T : TBase;

        SubscribeSocket socket = new SubscribeSocket();
        NanomsgEndpoint endpoint;
        bool disposing = false;
        List<string> topics = new List<string>();

        Task receivingThread = null;
        CancellationTokenSource cts;

        Dictionary<string, Delegate> MsgHandlers = new Dictionary<string, Delegate>();

        public static PubSubSink CreateInstance(string serverUri)
        {
            var ret = new PubSubSink();
            ret.endpoint = ret.socket.Connect(serverUri);
            return ret;
        }

        private PubSubSink()
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
                //var tokens = Thread.CurrentThread.Name?.Split(ThreadNameToken);
                //receivingThread.Name = ((tokens == null || tokens.Length == 0) ? topic : tokens[0]) + ThreadNameToken + "Subscriber";
                //receivingThread.Start();
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
            Logging.Logger.Log(message, level: level, category: Logging.MessageCategory.Subscriber);
        }

        static readonly TimeSpan ReceiveTimeout = TimeSpan.FromMilliseconds(500);

        async Task<bool> Receive()
        {
            try
            {
                // Use non-blocking call here so we're able to stop the receive thread
                var msg = socket.ReceiveImmediate();
                if (msg != null)
                {
                    if (PubSubUtil.IsStoppingMessage(msg))
                    {
                        PublisherLogger.Info("subscribe client stopped by stpping message!");
                        return false;
                    }

                    // Thrift serialized messages follow 0 delimiting topic.  See PubSubSource::Send() for details.
                    int index = -1;
                    for (int i = 0; i < msg.Length; ++i)
                    {
                        if (msg[i] == 0)
                        {
                            // Skip the trailing 0
                            index = i + 1;
                            break;
                        }
                    }
                    if (index == -1)
                    {
                        return true;
                    }

                    // Everything up to but not including 0
                    var topic = System.Text.Encoding.ASCII.GetString(msg, 0, index - 1);

                    // Everything after the topic delimiting 0
                    var stream = new MemoryStream(msg, index, msg.Length - index);
                    using (var trans = new TStreamClientTransport(stream, stream))
                    using (var proto = new TBinaryProtocol(trans))
                    {
                        var header = new SDK.PublisherSubscriber.PubHeader();
                        await header.ReadAsync(proto, cts.Token);
                        var msgType = header.PayloadType;
                        if (MsgHandlers.TryGetValue(msgType, out Delegate mh))
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
                    Log($"SubscribeClient, invoke exception: {(ee).InnerException.Message} \n {ee.InnerException.StackTrace}", Logging.LogLevel.Warn);
                    return true;
                }
                //if (e is TerminatingException)
                //{
                //    Log($"SubscribeClient, terminated: {e.Message}", Logging.LogLevel.Info);
                //    return false;
                //}
                else
                {
                    Log(disposing ? $"SubscribeClient, disposing exception: {e.Message}" : $"subscribe client receive exception: {e.Message} \n {e.StackTrace}",
                        disposing ? Logging.LogLevel.Info : Logging.LogLevel.Error
                        );
                    return false;
                }
            }
        }

        #region IDisposable
        public void Dispose()
        {
            disposing = true;

            // Need to stop Receive thread before attempting to close socket.  If socket is used after dispose() nng calls abort()...
            try
            {
                if (receivingThread != null)
                {
                    cts.Cancel();
                    receivingThread.Wait();
                    receivingThread = null;
                }
            }
            catch
            {
                Log($"receiving thread aborted", Logging.LogLevel.Info);
            }

            MsgHandlers.Clear();
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
                        Log($"subscribe client terminated: { e.Message }", Logging.LogLevel.Error);
                    }
                }
                try
                {
                    socket.Dispose();
                    socket = null;
                }
                catch { }
            }

            
        }
    }
    #endregion
}
