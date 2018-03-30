using System;

namespace Ruyi
{
    public class VariableFactory<TValue>
    {
        public VariableFactory(Func<TValue> variablePriorInitializer)
        {
            mVariablePriorInitializer = variablePriorInitializer;
        }

        public Variable<TValue> CreateBasicVariable(string nameFormat, params object[] args)
        {
            var newVar = new Variable<TValue>(String.Format(nameFormat, args), mVariablePriorInitializer());
            return newVar;
        }

        public KeyedVariable<TKey, TValue> CreateKeyedVariable<TKey>(TKey key, string nameFormat, params object[] args)
        {
            var newVar = new KeyedVariable<TKey, TValue>(key, String.Format(nameFormat, args), mVariablePriorInitializer());
            return newVar;
        }

        private readonly Func<TValue> mVariablePriorInitializer;
    }
}
