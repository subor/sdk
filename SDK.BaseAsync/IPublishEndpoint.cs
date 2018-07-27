using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Thrift.Protocols;
using Thrift.Transports.Client;

namespace Ruyi.Layer0
{
    public interface IPublishEndpoint : IDisposable
    {
        Task<bool> Send<T>(T msg) where T : TBase;
    }
}
