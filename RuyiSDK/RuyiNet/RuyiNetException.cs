using System;

namespace Ruyi
{
    internal class RuyiNetException : Exception
    {
        public RuyiNetException()
        {
        }

        public RuyiNetException(string message)
        : base(message)
        {
        }

        public RuyiNetException(string message, Exception inner)
        : base(message, inner)
    {
        }
    }
}
