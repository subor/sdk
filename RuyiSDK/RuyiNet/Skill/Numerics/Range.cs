using System;

namespace Ruyi.SDK.Cloud
{
    /// <summary>
    /// Represents a range of numbers.
    /// </summary>
    /// <typeparam name="T">The type used with this range.</typeparam>
    public abstract class Range<T> where T : Range<T>, new()
    {
        /// <summary>
        /// Create an inclusive range.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns>The newly created range.</returns>
        public static T Inclusive(int min, int max)
        {
            return gInstance.Create(min, max);
        }

        /// <summary>
        /// Creates a range that has to be exactly one value.
        /// </summary>
        /// <param name="value">The value this range requires.</param>
        /// <returns>The newly created range.</returns>
        public static T Exactly(int value)
        {
            return gInstance.Create(value, value);
        }

        /// <summary>
        /// Creates a range that only has a minimum value.
        /// </summary>
        /// <param name="minimumValue">The minimum value.</param>
        /// <returns>The newly created range.</returns>
        public static T AtLeast(int minimumValue)
        {
            return gInstance.Create(minimumValue, int.MaxValue);
        }

        /// <summary>
        /// Check if a value is in range.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <returns>True if the value is in range, false otherwise.</returns>
        public bool IsInRange(int value)
        {
            return (Min <= value) && (value <= Max);
        }

        /// <summary>
        /// The minumum  value of this range.
        /// </summary>
        public int Min { get; private set; }

        /// <summary>
        /// The maximum value of this range.
        /// </summary>
        public int Max { get; private set; }

        /// <summary>
        /// Create a new range.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        protected Range(int min, int max)
        {
            if (min > max)
            {
                throw new ArgumentOutOfRangeException();
            }

            Min = min;
            Max = max;
        }

        /// <summary>
        /// Create a new range.
        /// </summary>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns>The newly created range.</returns>
        protected abstract T Create(int min, int max);

        private static readonly T gInstance = new T();
    }
}
