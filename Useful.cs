using System;

namespace Evolution
{
    static class Useful
    {
        public static Random r = new Random();
        public const float Divider = 10;
        public const int Invalid = -1;

        public static int Clamp(int number, int min, int max)
        {
            if (number < min) number = min;
            else if (number > max) number = max - 1;
            return number;
        }
    }
}
