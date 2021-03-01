using System;

namespace Evolution
{
    class Point
    {
        float _x, _y;

        public float X { get { return _x; } }
        public float Y { get { return _y; } }

        public Point(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public void Add(Point other)
        {
            _x += other.X;
            _y += other.Y;
        }

        public float Manhattan(Point other)
        {
            return (float) Math.Sqrt(Math.Pow(Math.Abs(_x - other.X), 2) + Math.Pow(Math.Abs(_y - other.Y), 2));
        }

        public override string ToString()
        {
            string print = $"({_x}, {_y})";
            return print;
        }
    }
}
