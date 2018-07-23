using Ruyi.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Thrift.Protocols;
using Thrift.Protocols.Entities;
using Thrift.Transports;

namespace Ruyi.Layer0
{
    /// <summary>
    /// only use it on thrift client side, lock when write start and unlock when read end.
    /// </summary>
    public class TBinaryProtocolTS : TBinaryProtocol
    {
        private const int ConnectRetryTimesMax = 5;
        private int connectRetryTimes = ConnectRetryTimesMax;
        private bool needReconnect = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="trans"></param>
        public TBinaryProtocolTS(TClientTransport trans) : base(trans)
        {
        }

        /// <summary>
        /// logger.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level"></param>
        virtual protected void Log(string message, LogLevel level)
        {
            Logger.Log(message, category: MessageCategory.Framework, level: level);
        }

        /// <summary>
        /// begin to write the message, see if we need to create a new transport
        /// </summary>
        /// <param name="message"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public override async Task WriteMessageBeginAsync(TMessage message, CancellationToken token)
        {
            await semaphore.WaitAsync();

            while (true)
            {
                if (!needReconnect)
                {
                    try
                    {
                        await base.WriteMessageBeginAsync(message, CancellationToken.None);

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
                        if (Transport is TTransportTS ttt)
                        {
                            await ttt.Reconnect();
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

        /// <summary>
        /// read message end, release the transport
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public override async Task ReadMessageEndAsync(CancellationToken token)
        {
            await base.ReadMessageEndAsync(token);
            semaphore.Release();
        }

        SemaphoreSlim semaphore = new SemaphoreSlim(1);
    }
}
