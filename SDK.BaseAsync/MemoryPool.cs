using System.IO;

namespace Ruyi.Common
{
    /// <summary>
    /// Pooled <see cref="System.IO.MemoryStream"/>
    /// </summary>
    /// <remarks>
    /// Via http://www.philosophicalgeek.com/2015/02/06/announcing-microsoft-io-recycablememorystream/
    /// </remarks>
    public static class MemoryPool
    {
        /// <summary>
        /// Gets a <see cref="MemoryStream"/> from the pool.
        /// </summary>
        /// <returns></returns>
        public static MemoryStream GetStream()
        {
            return streamManager.GetStream();
        }

        /// <summary>
        /// Gets a <see cref="MemoryStream"/> from the pool initialized with <paramref name="buffer"/>.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <returns></returns>
        public static MemoryStream GetStream(byte[] buffer)
        {
            return streamManager.GetStream(string.Empty, buffer, 0, buffer.Length);
        }

        static Microsoft.IO.RecyclableMemoryStreamManager streamManager = new Microsoft.IO.RecyclableMemoryStreamManager();
    }
}