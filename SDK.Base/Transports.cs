using System;
using System.Net.Sockets;
using System.Threading;
using Thrift.Transport;

namespace Layer0
{
    public interface TTransportTS
    {
        void SetWriteLocker(object locker);
        void Reconnect();
    }

    public class TStreamTransportTS : TStreamTransport, TTransportTS
    {
        object writeLocker = null;

        public void SetWriteLocker(object locker)
        {
            writeLocker = locker;
        }

        public override void Flush()
        {
            base.Flush();

            if (writeLocker != null)
                Monitor.Exit(writeLocker);
        }

        public override IAsyncResult BeginFlush(AsyncCallback callback, object state)
        {
            return null;
        }

        public override void EndFlush(IAsyncResult asyncResult)
        {
            if (writeLocker != null)
                Monitor.Exit(writeLocker);
        }

        public void Reconnect()
        {
            Close();
            Open();
        }
    }

    public class TSocketTransportTS : TSocket, TTransportTS
    {
        object writeLocker = null;

        public TSocketTransportTS(TcpClient client) : base(client)
        { }

        public TSocketTransportTS(string host, int port) : base(host, port)
        { }

        public TSocketTransportTS(string host, int port, int timeout) : base(host, port, timeout)
        { }

        public void SetWriteLocker(object locker)
        {
            writeLocker = locker;
        }

        public override void Flush()
        {
            base.Flush();

            if (writeLocker != null)
                Monitor.Exit(writeLocker);
        }

        public override IAsyncResult BeginFlush(AsyncCallback callback, object state)
        {
            return null;
        }

        public override void EndFlush(IAsyncResult asyncResult)
        {
            if (writeLocker != null)
                Monitor.Exit(writeLocker);
        }

        public void Reconnect()
        {
            Close();
            Open();
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

        public override void Flush()
        {
            base.Flush();

            if (writeLocker != null)
                Monitor.Exit(writeLocker);
        }

        public override IAsyncResult BeginFlush(AsyncCallback callback, object state)
        {
            return null;
        }

        public override void EndFlush(IAsyncResult asyncResult)
        {
            if (writeLocker != null)
                Monitor.Exit(writeLocker);
        }

        public void Reconnect()
        {
            Close();
            Open();
        }
    }

}
