using System;

namespace Evolution
{
    class World
    {
        static Random r = new Random();

        const int _minSize = 100000;
        const int _maxSize = 1000000;

        public static int Height { get { return r.Next(_minSize, _maxSize) / GlobalConstants.RandomDivider; } }
        public static int Width { get { return r.Next(_minSize, _maxSize) / GlobalConstants.RandomDivider; } }
    }
}
