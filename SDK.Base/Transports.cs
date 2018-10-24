using System;
using System.Net.Sockets;
using System.Threading;
using Thrift.Transport;

namespace Ruyi.Layer0
{
    /// <summary>
    /// interface for TTransport implemented class 
    /// </summary>
    public interface TTransportTS
    {
        /// <summary>
        /// set muted locker
        /// </summary>
        /// <param name="locker">locker</param>
        void SetWriteLocker(object locker);

        /// <summary>
        /// reconnect between C/S
        /// </summary>
        void Reconnect();
    }

    /// <summary>
    /// Wrappered TStreamTransport class
    /// </summary>
    public class TStreamTransportTS : TStreamTransport, TTransportTS
    {
        object writeLocker = null;

        /// <summary>
        /// set muted locker
        /// </summary>
        public void SetWriteLocker(object locker)
        {
            writeLocker = locker;
        }

        /// <summary>
        /// clears all buffers for this stream
        /// </summary>
        public override void Flush()
        {
            base.Flush();

            if (writeLocker != null)
                Monitor.Exit(writeLocker);
        }

        /// <summary>
        /// begin flush asyncly
        /// </summary>
        /// <param name="callback">callback delegate</param>
        /// <param name="state">state</param>
        public override IAsyncResult BeginFlush(AsyncCallback callback, object state)
        {
            return null;
        }

        /// <summary>
        /// end flush acyncly
        /// </summary>
        /// <param name="asyncResult">result</param>
        public override void EndFlush(IAsyncResult asyncResult)
        {
            if (writeLocker != null)
                Monitor.Exit(writeLocker);
        }

        /// <summary>
        /// reconnect between C/S
        /// </summary>
        public void Reconnect()
        {
            Close();
            Open();
        }
    }

    /// <summary>
    /// Wrappered TSocket class
    /// </summary>
    public class TSocketTransportTS : TSocket, TTransportTS
    {
        object writeLocker = null;

        /// <summary>
        /// constructor of TSocketTransportTS with TcpClient
        /// </summary>
        /// <param name="client">client</param>
        public TSocketTransportTS(TcpClient client) : base(client)
        { }

        /// <summary>
        /// constructor of TSocketTransportTS with host and port
        /// </summary>
        /// <param name="host">host</param>
        /// <param name="port">port</param>
        public TSocketTransportTS(string host, int port) : base(host, port)
        { }

        /// <summary>
        /// constructor of TSocketTransportTS with host,port and timeout
        /// </summary>
        /// <param name="host">host</param>
        /// <param name="port">port</param>
        /// <param name="timeout">timeout</param>
        public TSocketTransportTS(string host, int port, int timeout) : base(host, port, timeout)
        { }

        /// <summary>
        /// set muted locker
        /// </summary>
        public void SetWriteLocker(object locker)
        {
            writeLocker = locker;
        }

        /// <summary>
        /// clears all buffers for this stream
        /// </summary>
        public override void Flush()
        {
            base.Flush();

            if (writeLocker != null)
                Monitor.Exit(writeLocker);
        }

        /// <summary>
        /// begin flush asyncly
        /// </summary>
        /// <param name="callback">callback delegate</param>
        /// <param name="state">state</param>
        public override IAsyncResult BeginFlush(AsyncCallback callback, object state)
        {
            return null;
        }

        /// <summary>
        /// end flush acyncly
        /// </summary>
        /// <param name="asyncResult">result</param>
        public override void EndFlush(IAsyncResult asyncResult)
        {
            if (writeLocker != null)
                Monitor.Exit(writeLocker);
        }

        /// <summary>
        /// reconnect between C/S
        /// </summary>
        public void Reconnect()
        {
            Close();
            Open();
        }
    }

    /// <summary>
    /// Wrappered TNamedPipeClientTransport class
    /// </summary>
    public class TNamedPipeClientTransportTS : TNamedPipeClientTransport, TTransportTS
    {
        object writeLocker = null;

        /// <summary>
        /// constructor of TNamedPipeClientTransportTS with pipe
        /// </summary>
        /// <param name="pipe">pipe</param>
        public TNamedPipeClientTransportTS(string pipe) : base(pipe)
        { }

        /// <summary>
        /// constructor of TNamedPipeClientTransportTS with server and pipe
        /// </summary>
        /// <param name="server">server</param>
        /// <param name="pipe">pipe</param>
        public TNamedPipeClientTransportTS(string server, string pipe) : base(server, pipe)
        { }

        /// <summary>
        /// set muted locker
        /// </summary>
        public void SetWriteLocker(object locker)
        {
            writeLocker = locker;
        }

        /// <summary>
        /// clears all buffers for this stream
        /// </summary>
        public override void Flush()
        {
            base.Flush();

            if (writeLocker != null)
                Monitor.Exit(writeLocker);
        }

        /// <summary>
        /// begin flush asyncly
        /// </summary>
        /// <param name="callback">callback delegate</param>
        /// <param name="state">state</param>
        public override IAsyncResult BeginFlush(AsyncCallback callback, object state)
        {
            return null;
        }

        /// <summary>
        /// end flush acyncly
        /// </summary>
        /// <param name="asyncResult">result</param>
        public override void EndFlush(IAsyncResult asyncResult)
        {
            if (writeLocker != null)
                Monitor.Exit(writeLocker);
        }

        /// <summary>
        /// reconnect between C/S
        /// </summary>
        public void Reconnect()
        {
            Close();
            Open();
        }
    }

}
