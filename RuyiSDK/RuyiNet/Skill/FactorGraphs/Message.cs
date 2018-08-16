using System;

namespace Ruyi.SDK.Online
{
    public class Message<T>
    {
        public Message()
            : this(default(T), null, null)
        {
        }

        public Message(T value, string nameFormat, params object[] args)
        {
            mNameFormat = nameFormat;
            mNameFormatArgs = args;
            Value = value;
        }

        public T Value { get; set; }

        public override string ToString()
        {
            return (mNameFormat == null) ? base.ToString() : String.Format(mNameFormat, mNameFormatArgs);
        }

        private readonly string mNameFormat;
        private readonly object[] mNameFormatArgs;
    }
}
