using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Thrift.Transports.Client;

namespace Ruyi.Layer0
{
    public interface TTransportTS
    {
        void SetWriteLocker(object locker);
        Task Reconnect();
    }

    public class TStreamTransportTS : TStreamClientTransport, TTransportTS
    {
        object writeLocker = null;

        public void SetWriteLocker(object locker)
        {
            writeLocker = locker;
        }

        public override async Task FlushAsync()
        {
            await base.FlushAsync();

            if (writeLocker != null)
                Monitor.Exit(writeLocker);
        }
        
        public Task Reconnect()
        {
            Close();
            return OpenAsync();
        }
    }

    public class TSocketTransportTS : TSocketClientTransport, TTransportTS
    {
        object writeLocker = null;

        public TSocketTransportTS(TcpClient client) : base(client)
        { }

        public TSocketTransportTS(System.Net.IPAddress host, int port) : base(host, port)
        { }

        public TSocketTransportTS(System.Net.IPAddress host, int port, int timeout) : base(host, port, timeout)
        { }

        public void SetWriteLocker(object locker)
        {
            writeLocker = locker;
        }

        public override async Task FlushAsync()
        {
            await base.FlushAsync();

            if (writeLocker != null)
                Monitor.Exit(writeLocker);
        }
        
        public Task Reconnect()
        {
            Close();
            return OpenAsync();
        }
    }

    public class TNamedPipeClientTransportTS : TNamedPipeClientTransport, TTransportTS
    {
        object writeLocker = null;

        public TNamedPipeClientTransportTS(string pipe) : base(pipe)
        { }

        public TNamedPipeClientTransportTS(string server, string pipe) : base(server, pipe)
        { }

        public void SetWriteLocker(object locker)
        {
            writeLocker = locker;
        }

        public override async Task FlushAsync()
        {
            await base.FlushAsync();

            if (writeLocker != null)
                Monitor.Exit(writeLocker);
        }
        
        public Task Reconnect()
        {
            Close();
            return OpenAsync();
        }
    }

}
