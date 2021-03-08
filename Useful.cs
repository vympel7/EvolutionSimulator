using System;

namespace Evolution
{
    static class Useful
    {
        public static Random r = new Random();
        public const float Divider = 10;
        public const int Invalid = -1;

        /// <summary>
        /// Ensures a number is between a minimum (inclusive) and a maximum (exclusive) value
        /// </summary>
        /// <returns>The number clamped between min and max</returns>
        /// <param name="number">The number to clamp between min and max</param>
        /// <param name="min">The minimum value number can have</param>
        /// <param name="max">The maximum value (-1) number can have</param>
        public static float Clamp(float number, float min, float max)
        {
            if (number < min) number = min;
            else if (number >= max) number = max - 1;
            return number;
        }

        public static float Lerp(int x, int minC, int maxC, float a, float b) //fix, now only works for  0 <= x <= 1
        {
            float min = a > b ? b : a;

            float d = b - min;

            return min + d * x;
        }
    }
}
