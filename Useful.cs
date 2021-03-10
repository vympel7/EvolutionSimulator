using System;

namespace Evolution
{
    static class Useful
    {
        public static Random Rand = new Random();
        public const float Divider = 10;
        public const int Invalid = -1;

        /// <summary>
        /// Ensures a number is between a minimum (inclusive) and a maximum (exclusive) value
        /// </summary>
        /// <param name="number">The number to clamp between min and max</param>
        /// <param name="min">The minimum value (inclusive) number can have</param>
        /// <param name="max">The maximum value (exclusive) number can have</param>
        /// <returns>The number clamped between min and max</returns>
        public static float Clamp(float number, float min, float max)
        {
            if (min > max) throw new ArgumentException("min must be lower or equal to max", "min");
            if (number < min) number = min;
            else if (number >= max) number = max - 1;
            return number;
        }

        /// <summary>
        /// Maps a value from a range to another
        /// </summary>
        /// <param name="x">The control variable that is used to adjust the outcome</param>
        /// <param name="minC">The minimum value (inclusive) of the control variable</param>
        /// <param name="maxC">The maximum value (inclusive) of the control variable</param>
        /// <param name="a">The number bound to minC</param>
        /// <param name="b">The number bound to maxC</param>
        /// <returns>A properly mapped value between a and b</returns>
        public static float Map(float x, float minC, float maxC, float a, float b)
        {
            if (x > maxC || x < minC) throw new ArgumentOutOfRangeException("x", x, "x must be between a and b (both inclusive)");
            if (minC > maxC) throw new ArgumentException("minC must be lower than maxC", "minC");
            if (a > b) throw new ArgumentException("a must be lower or equal to b", "a");

            return a + (b - a) / (maxC - minC) * (x - minC);
        }
    }
}
