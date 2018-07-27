using System.IO;

namespace Ruyi.Common
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// http://www.philosophicalgeek.com/2015/02/06/announcing-microsoft-io-recycablememorystream/
    /// </remarks>
    public static class MemoryPool
    {
        public static MemoryStream GetStream()
        {
            return streamManager.GetStream();
        }

        public static MemoryStream GetStream(byte[] buffer)
        {
            return streamManager.GetStream(string.Empty, buffer, 0, buffer.Length);
        }

        static Microsoft.IO.RecyclableMemoryStreamManager streamManager = new Microsoft.IO.RecyclableMemoryStreamManager();
    }
}