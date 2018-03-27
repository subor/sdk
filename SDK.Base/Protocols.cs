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
                        Logger.Log(new LoggerMessage()
                        {
                            Level = LogLevel.Warn,
                            Message = "connection error, try to reconnect",
                            Category = MessageCategory.Framework,
                        });
                        needReconnect = true;
                    }
                }

                if (needReconnect)
                {
                    if (connectRetryTimes <= 0)
                    {
                        Logger.Log(new LoggerMessage()
                        {
                            Level = LogLevel.Error,
                            Message = $"Connection Error, after tried for {ConnectRetryTimesMax} times to reconnect, give up",
                            Category = MessageCategory.Framework,
                        });

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
                        Logger.Log(new LoggerMessage()
                        {
                            Level = LogLevel.Error,
                            Message = e.Message,
                            Category = MessageCategory.Framework,
                        });
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
