using Ruyi.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Thrift;
using Thrift.Protocols;
using Thrift.Transports.Client;

namespace Ruyi.Layer0
{
    public static class ThriftUtil
    {
        public static (TProtocol, MemoryStream) CreateWriteProtocol(byte[] data = null)
        {
            MemoryStream istream = null;
            if (data != null && data.Length > 0)
            {
                istream = Common.MemoryPool.GetStream(data);
            }
            var ostream = Common.MemoryPool.GetStream();
            var proto = CreateWriteProtocol(istream, ostream);
            return (proto, ostream);
        }

        public static TProtocol CreateWriteProtocol(Stream inputStream, Stream outputStream)
        {
            var trans = new TStreamClientTransport(inputStream, outputStream);
            var proto = new TBinaryProtocol(trans);
            return proto;
        }

        public static TProtocol CreateReadProtocol(byte[] data)
        {
            var istream = Common.MemoryPool.GetStream(data);
            var proto = CreateReadProtocol(istream);
            return proto;
        }

        public static TProtocol CreateReadProtocol(Stream inputStream)
        {
            var trans = new TStreamClientTransport(inputStream, null);
            var proto = new TBinaryProtocol(trans);
            return proto;
        }
    }
}