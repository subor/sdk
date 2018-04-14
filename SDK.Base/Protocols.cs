using RuyiLogger;
using System;
using System.Threading;
using Thrift.Protocol;
using Thrift.Transport;

namespace Layer0
{
    // only use it on thrift client side, lock when write start and unlock when read end.
    public class TBinaryProtocolTS : TBinaryProtocol
    {
        private const int ConnectRetryTimesMax = 5;

        private object locker = new object();

        private int connectRetryTimes = ConnectRetryTimesMax;
        private bool needReconnect = false;

        public TBinaryProtocolTS(TTransport trans) : base(trans)
        {
        }

        void Log(string message, LogLevel level)
        {
            Logger.Log(message, category: MessageCategory.Framework, level: level);
        }

        // begin to write the message, see if we need to create a new transport
        public override void WriteMessageBegin(TMessage message)
        {
            Monitor.Enter(locker);

            while (true)
            {
                if (!needReconnect)
                {
                    try
                    {
                        base.WriteMessageBegin(message);

                        // reset retry times when send succeed.
                        connectRetryTimes = ConnectRetryTimesMax;
                    }
                    catch (Exception)
                    {
                        Log("connection error, try to reconnect", LogLevel.Warn);
                        needReconnect = true;
                    }
                }

                if (needReconnect)
                {
                    if (connectRetryTimes <= 0)
                    {
                        Log($"Connection Error, after tried for {ConnectRetryTimesMax} times to reconnect, give up", LogLevel.Error);

                        // reset retry times, so we can actually retry to connect at next send.
                        connectRetryTimes = ConnectRetryTimesMax;
                        break;
                    }

                    connectRetryTimes--;
                    try
                    {
                        if (Transport is TTransportTS)
                        {
                            var ttt = Transport as TTransportTS;
                            ttt.Reconnect();
                        }

                        needReconnect = false;
                    }
                    catch (Exception e)         // reconnect exception, retry agian.
                    {
                        Log(e.Message, LogLevel.Error);
                    }
                }
                else
                {
                    break;
                }
            }
        }

        // read message end, release the transport
        public override void ReadMessageEnd()
        {
            base.ReadMessageEnd();

            Monitor.Exit(locker);
        }

    }
}
