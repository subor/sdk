using System;
using System.Threading.Tasks;
using Thrift.Protocols;

namespace Ruyi.Layer0
{
    /// <summary>
    /// Interface for publisher in publisher/subscriber pattern
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IPublishEndpoint : IDisposable
    {
        Task<bool> Send<T>(T msg) where T : TBase;
    }

    /// <summary>
    /// Handler called when pub/sub message is received
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="topic">The topic.</param>
    /// <param name="msg">The MSG.</param>
    /// <remarks>
    /// See <see cref="ISubscribeClient"/>
    /// </remarks>
    public delegate void MessageHandler<T>(string topic, T msg) where T : TBase;

    /// <summary>
    /// Inteface for subscriber in publisher/subscriber pattern
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface ISubscribeClient : IDisposable
    {
        void Subscribe(string topic);

        void Unsubscribe(string topic);

        void AddGenericMessageHandler(string typeName, MessageHandler<TBase> mh);

        void RemoveGenericMessageHandler(string typeName, MessageHandler<TBase> mh);

        void AddMessageHandler<T>(MessageHandler<T> mh) where T : TBase;

        void RemoveMessageHandler<T>(MessageHandler<T> mh) where T : TBase;
    }
}
