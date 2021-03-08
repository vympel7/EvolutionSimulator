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
            _x = Useful.r.Next(0, World.Width * 10) / Useful.Divider;
            _y = Useful.r.Next(0, World.Height * 10) / Useful.Divider;
        }

        public Point(float x, float y)
        {
            _x = Useful.Clamp(x, 0, World.Width);
            _y = Useful.Clamp(y, 0, World.Height);
        }

        public void Add(Point other)
        {
            _x += other.X;
            _y += other.Y;
        }

        public float Manhattan(Point other)
        {
            return (float)Math.Sqrt(Math.Pow(Math.Abs(_x - other.X), 2) + Math.Pow(Math.Abs(_y - other.Y), 2));
        }

        public override string ToString()
        {
            string print = $"({_x}, {_y})";
            return print;
        }
    }
}
