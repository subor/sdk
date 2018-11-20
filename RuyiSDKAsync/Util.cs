using System.Linq;

namespace Ruyi.Util
{
    public static class Helpers
    {
        /// <summary>
        /// Converts string to IP address
        /// </summary>
        /// <param name="hostnameOrAddress"></param>
        /// <returns></returns>
        public static System.Net.IPAddress GetIPAddress(string hostnameOrAddress, System.Net.Sockets.AddressFamily addressFamily = System.Net.Sockets.AddressFamily.InterNetwork)
        {
            if (System.Net.IPAddress.TryParse(hostnameOrAddress, out var address))
            {
                return address;
            }
            else
            {
                // If couldn't parse as an IP address then try DNS lookup
                var addrs = System.Net.Dns.GetHostAddresses(hostnameOrAddress);
                var res = addrs.Where(addr => addr.AddressFamily == addressFamily).FirstOrDefault();
                return res;
            }
        }
    }
    
}