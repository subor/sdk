using Ruyi.Logging;
using NetMQ;
using NetMQ.Sockets;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ruyi.DevTool
{
    public class SocketLogReceiver
    {
        public delegate void ReceiveCallback(LoggerMessage msg);

        CancellationTokenSource cancel = null;
        DealerSocket subSocket = new DealerSocket();
        ReceiveCallback receiveCallback = null;

        public void Connect(string url, string identity, ReceiveCallback cb)
        {
            subSocket.Options.Identity = Encoding.ASCII.GetBytes(identity);
            subSocket.Connect(url);
            subSocket.ReceiveReady += Receive;
            receiveCallback = cb;

            cancel = new CancellationTokenSource();
            Task.Factory.StartNew(() =>
            {
                while (!cancel.IsCancellationRequested)
                {
                    subSocket.Poll();
                }
            }, cancel.Token);
        }

        public void Stop()
        {
            // TODO, send stop msg to broker to stop the socket logger.
            cancel.Cancel();
            subSocket.Close();
            subSocket.Dispose();
        }

        void Receive(object sender, NetMQSocketEventArgs evt)
        {
            NetMQMessage msg = null;
            try
            {
                msg = subSocket.ReceiveMultipartMessage();
            }
            catch (Exception e)
            {
                Console.WriteLine("pub-sub client receive exception: " + e.Message);
            }
            var msgType = msg.Last.ConvertToString();
            LoggerMessage lm = JsonConvert.DeserializeObject<LoggerMessage>(msgType);
            receiveCallback?.Invoke(lm);
        }

        public void PlaybackLog(NetMQMessage msg)
        {
            msg.PushEmptyFrame();
            subSocket.SendMultipartMessage(msg);
        }

    }
}
