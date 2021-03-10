using System;

namespace Evolution
{
    class Point
    {
        float _x, _y;

        public float X { get { return _x; } set { _x = value; } }
        public float Y { get { return _y; } set { _y = value; } }


        public Point()
        {
            _x = Useful.Rand.Next(0, World.Width * 10) / Useful.Divider;
            _y = Useful.Rand.Next(0, World.Height * 10) / Useful.Divider;
        }

        public Point(float x, float y)
        {
            _x = Useful.Clamp(x, 0, World.Width);
            _y = Useful.Clamp(y, 0, World.Height);
        }

        /// <summary>
        /// Makes an element wise addition of this instance's coordinates and the parameter's
        /// </summary>
        /// <param name="other">The Point to take the coordinates from</param>
        public void Add(Point other)
        {
            _x += other.X;
            _y += other.Y;
        }

        /// <summary>
        /// Evaluates a manhattan distance between this instance's coordinates and the parameter's
        /// </summary>
        /// <param name="other">The Point to take the coordinates from</param>
        /// <returns>The manhattan distance of the coordinates</returns>
        public float Manhattan(Point other)
        {
            return (float)Math.Sqrt(Math.Pow(Math.Abs(_x - other.X), 2) + Math.Pow(Math.Abs(_y - other.Y), 2));
        }

        public override string ToString()
        {
            return $"({_x}, {_y})";
        }
    }
}
