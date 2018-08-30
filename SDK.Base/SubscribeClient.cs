using NetMQ;
using NetMQ.Sockets;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using Thrift.Protocol;
using Thrift.Transport;

namespace Ruyi.Layer0
{
    /// <summary>
    /// Client to subscribe to publishers.
    /// </summary>
    /// <example>
    /// Getting gamepad/controler input:
    /// <code source="layer0/sdktest/doctests.cs" region="Subscribe_Input"></code>
    /// </example>
    public class SubscribeClient : IDisposable
    {
        /// <summary>
        /// The thread name token
        /// </summary>
        /// <exclude/>
        public const char ThreadNameToken = '|';

        /// <summary>
        /// Handles pub/sub messages.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="topic">The topic.</param>
        /// <param name="message">The message.</param>
        public delegate void MessageHandler<T>(string topic, T message) where T : TBase;

        SubscriberSocket socket = new SubscriberSocket();
        bool disposing = false;
        // Not used but useful for debuging
#pragma warning disable 414
        string serverUri = null;
#pragma warning restore 414
        List<string> topics = new List<string>();

        Thread receivingThread = null;

        Dictionary<string, Delegate> MsgHandlers = new Dictionary<string, Delegate>();

        /// <summary>
        /// Creates <see cref="SubscribeClient"/> instance.
        /// </summary>
        /// <param name="serverUri">The server URI.</param>
        /// <returns></returns>
        /// <remarks>
        /// Both the public SDK and internal SDK already provide an instance.
        /// </remarks>
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

        /// <summary>
        /// Subscribes to the specified topic.
        /// </summary>
        /// <param name="topic">The topic.</param>
        /// <remarks>
        /// Each service publishes to topic returned by <see cref="Ruyi.Layer0.ServiceHelper.PubChannelID(ServiceIDs)"/>.
        /// </remarks>
        public void Subscribe(string topic)
        {
            if (string.IsNullOrEmpty(topic) || topics.Contains(topic))
                return;

            topics.Add(topic);
            socket.Subscribe(topic);
            if (topics.Count > 0 && receivingThread == null)
            {
                receivingThread = new Thread(() =>
                {
                    while (Receive()) ;
                });
                var tokens = Thread.CurrentThread.Name?.Split(ThreadNameToken);
                receivingThread.Name = ((tokens == null || tokens.Length == 0) ? topic : tokens[0]) + ThreadNameToken + "Subscriber";
                receivingThread.Start();
            }
        }

        /// <summary>
        /// Unsubscribes from the specified topic.
        /// </summary>
        /// <param name="topic">The topic.</param>
        public void Unsubscribe(string topic)
        {
            if (!topics.Contains(topic))
                return;

            topics.Remove(topic);
            socket.Unsubscribe(topic);
        }

        /// <summary>
        /// Adds the generic message handler.
        /// </summary>
        /// <param name="typeName">Name of the type.</param>
        /// <param name="messageHandler">The message handler.</param>
        /// <seealso cref="RemoveGenericMessageHandler(string, MessageHandler{TBase})"/>
        public void AddGenericMessageHandler(string typeName, MessageHandler<TBase> messageHandler)
        {
            if (messageHandler == null)
                return;

            string tp = typeName;
            if (!MsgHandlers.ContainsKey(tp))
                MsgHandlers.Add(tp, messageHandler);
            else
                MsgHandlers[tp] = Delegate.Combine(MsgHandlers[tp], messageHandler);
        }

        /// <summary>
        /// Removes the generic message handler.
        /// </summary>
        /// <param name="typeName">Name of the type.</param>
        /// <param name="messageHandler">The message handler.</param>
        /// <seealso cref="AddGenericMessageHandler(string, MessageHandler{TBase})"/>
        public void RemoveGenericMessageHandler(string typeName, MessageHandler<TBase> messageHandler)
        {
            string tp = typeName;
            if (MsgHandlers.ContainsKey(tp))
                MsgHandlers[tp] = Delegate.Remove(MsgHandlers[tp], messageHandler);
        }

        /// <summary>
        /// Adds a message handler.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="messageHandler">The message handler.</param>
        /// <seealso cref="RemoveMessageHandler{T}(MessageHandler{T})"/>
        public void AddMessageHandler<T>(MessageHandler<T> messageHandler) where T : TBase
        {
            if (messageHandler == null)
                return;

            string tp = typeof(T).ToString();
            if (!MsgHandlers.ContainsKey(tp))
                MsgHandlers.Add(tp, messageHandler);
            else
                MsgHandlers[tp] = Delegate.Combine(MsgHandlers[tp], messageHandler);
        }

        /// <summary>
        /// Removes a message handler.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="messageHandler">The message handler.</param>
        /// <seealso cref="AddMessageHandler{T}(MessageHandler{T})"/>
        public void RemoveMessageHandler<T>(MessageHandler<T> messageHandler) where T : TBase
        {
            string tp = typeof(T).ToString();
            if (MsgHandlers.ContainsKey(tp))
                MsgHandlers[tp] = Delegate.Remove(MsgHandlers[tp], messageHandler);
        }

        void Log(string message, Logging.LogLevel level)
        {
            Logging.Logger.Log(message, level: level, category: Logging.MessageCategory.Subscriber);
        }

        bool Receive()
        {
            try
            {
                var msg = socket?.ReceiveMultipartMessage();
                if (msg == null || PubsubUtil.IsStoppingMessage(msg))
                {
                    PublisherLogger.Info("subscribe client stopped by stpping message!");
                    return false;
                }

                var topic = msg[0].ConvertToString();
                var msgType = msg[1].ConvertToString();
                if (MsgHandlers.TryGetValue(msgType, out Delegate mh))
                {
                    var respBytes = msg[2].Buffer;
                    var stream = new MemoryStream(respBytes, 0, respBytes.Length);
                    using (TStreamTransport trans = new TStreamTransport(stream, stream))
                    using (TBinaryProtocol proto = new TBinaryProtocol(trans))
                    {
                        Type t = GeneratedTypeCache.GetType(msgType);
                        if (t == null)
                            throw new TargetInvocationException(new Exception($"can't get type for: {msgType}"));
                        TBase ret = Activator.CreateInstance(t) as TBase;
                        ret.Read(proto);
                        mh.DynamicInvoke(topic, ret);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                if (e is TargetInvocationException)
                {
                    var ee = e as TargetInvocationException;
                    Log($"SubscribeClient, invoke exception: {(ee).InnerException.Message} \n {ee.InnerException.StackTrace}", Logging.LogLevel.Warn);
                    return true;
                }
                if (e is TerminatingException)
                {
                    Log($"SubscribeClient, terminated: {e.Message}", Logging.LogLevel.Info);
                    return false;
                }
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
                        var level = e is TerminatingException ? Logging.LogLevel.Info : Logging.LogLevel.Error;
                        Log($"subscribe client terminated: { e.Message }", level);
                    }
                }
                try
                {
                    socket.Dispose();
                    socket = null;
                }
                catch { }
            }

            // closing socket will throw an exception in Receive() which will be caught to end the thread.
            try
            {
                if (receivingThread != null && receivingThread.IsAlive)
                {
                    receivingThread.Abort();
                    receivingThread = null;
                }
            }
            catch {
                Log($"receiving thread aborted", Logging.LogLevel.Info);
            }
        }
    }
#endregion
}
