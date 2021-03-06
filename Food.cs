using System;

namespace Evolution
{
    class Food
    {
        const int _minNutrient = 5;
        const int _maxNutrient = 25 + 1;

        int _nutrient;
        Point _position;

        public int Nutrient { get { return _nutrient; } }
        public Point Position { get { return _position; } }

        public Food()
        {
            _nutrient = Useful.r.Next(_minNutrient, _maxNutrient);
            _position = new Point(Useful.r.Next(0, World.Width) / Useful.Divider, Useful.r.Next(0, World.Height) / Useful.Divider);
        }
    }
}
