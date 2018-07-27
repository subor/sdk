using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Thrift.Protocols;
using Thrift.Transports;
using Thrift.Transports.Client;

namespace Ruyi.Layer0
{
    public delegate void MessageHandler<T>(string topic, T msg) where T : TBase;

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
