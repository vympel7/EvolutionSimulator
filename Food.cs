using System;

namespace Evolution
{
    class Food
    {
        Random r = new Random();

        const int MinNutrient = 5;
        const int MaxNutrient = 25 + 1;

        int _nutrient;
        Point _position;

        public int Nutrient { get { return _nutrient; } }
        public Point Position { get { return _position; } }

        public Food()
        {
            _nutrient = r.Next(MinNutrient, MaxNutrient);
            _position = new Point(r.Next(0, World.Width) / GlobalConstants.RandomDivider, r.Next(0, World.Height) / GlobalConstants.RandomDivider);
        }
    }
}
