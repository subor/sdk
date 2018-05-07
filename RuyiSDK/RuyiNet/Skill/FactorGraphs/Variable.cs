using System;

namespace Ruyi.SDK.Cloud
{
    public class Variable<TValue>
    {
        public Variable(string name, TValue prior)
        {
            mName = "Variable[" + name + "]";
            mPrior = prior;
            ResetToPrior();
        }

        public void ResetToPrior()
        {
            Value = mPrior;
        }

        public override string ToString()
        {
            return mName;
        }

        public virtual TValue Value { get; set; }

        private readonly string mName;
        private readonly TValue mPrior;
    }

    public class DefaultVariable<TValue> : Variable<TValue>
    {
        public DefaultVariable()
            : base("Default", default(TValue))
        {
        }

        public override TValue Value
        {
            get { return default(TValue); }
            set { throw new NotSupportedException(); }
        }
    }

    public class KeyedVariable<TKey, TValue> : Variable<TValue>
    {
        public KeyedVariable(TKey key, string name, TValue prior)
            : base(name, prior)
        {
            Key = key;
        }

        public TKey Key { get; private set; }
    }
}
