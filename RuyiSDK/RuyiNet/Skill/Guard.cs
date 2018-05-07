using System;

namespace Ruyi.SDK.Cloud
{
    internal static class Guard
    {
        public static void ArgumentNotNull(object value, string parameterName)
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }

        public static void ArgumentIsValidIndex(int index, int count, string parameterName)
        {
            if ((index < 0) || (index >= count))
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }

        public static void ArgumentInRangeInclusive(double value, double min, double max, string parameterName)
        {
            if ((value < min) || (value > max))
            {
                throw new ArgumentOutOfRangeException(parameterName);
            }
        }
    }
}