using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Ruyi
{
    public abstract class Factor<TValue>
    {
        public virtual double UpdateMessage(int messageIndex)
        {
            Guard.ArgumentIsValidIndex(messageIndex, mMessages.Count, "messageIndex");
            return UpdateMessage(mMessages[messageIndex], mMessageToVariableBinding[mMessages[messageIndex]]);
        }

        public virtual void ResetMarginals()
        {
            foreach (var currentVariable in mMessageToVariableBinding.Values)
            {
                currentVariable.ResetToPrior();
            }
        }

        public virtual double SendMessage(int messageIndex)
        {
            Guard.ArgumentIsValidIndex(messageIndex, mMessages.Count, "messageIndex");

            var message = mMessages[messageIndex];
            var variable = mMessageToVariableBinding[message];
            return SendMessage(message, variable);
        }

        public override string ToString()
        {
            return mName ?? base.ToString();
        }

        public abstract Message<TValue> CreateVariableToMessageBinding(Variable<TValue> variable);

        public virtual double LogNormalization { get { return 0; } }
        public int NumberOfMessages { get { return mMessages.Count; } }

        protected Factor(string name)
        {
            mName = "Factor[" + name + "]";
        }

        protected virtual double UpdateMessage(Message<TValue> message, Variable<TValue> variable)
        {
            throw new NotImplementedException();
        }

        protected Message<TValue> CreateVariableToMessageBinding(Variable<TValue> variable, Message<TValue> message)
        {
            var index = mMessages.Count;
            mMessages.Add(message);
            mMessageToVariableBinding[message] = variable;
            mVariables.Add(variable);
            return message;
        }

        protected abstract double SendMessage(Message<TValue> message, Variable<TValue> variable);

        protected ReadOnlyCollection<Variable<TValue>> Variables { get { return mVariables.AsReadOnly(); } }
        protected ReadOnlyCollection<Message<TValue>> Messages { get { return mMessages.AsReadOnly(); } }

        private readonly List<Message<TValue>> mMessages = new List<Message<TValue>>();
        private readonly Dictionary<Message<TValue>, Variable<TValue>> mMessageToVariableBinding = new Dictionary<Message<TValue>, Variable<TValue>>();
        private readonly string mName;
        private readonly List<Variable<TValue>> mVariables = new List<Variable<TValue>>();
    }
}
