using System;

namespace Evolution
{
    class Food
    {
        static Random r = new Random();

        const int MinNutrient = 5;
        const int MaxNutrient = 25 + 1;

        int _nutrient;
        Tuple<float, float> _position;

        public int Nutrient { get { return _nutrient; } }
        public Tuple<float, float> Position { get { return _position; } }

        public Food()
        {
            _nutrient = r.Next(MinNutrient, MaxNutrient);
            _position = new Tuple<float, float>(r.Next(0, World.Width) / GlobalConstants.RandomDivider, r.Next(0, World.Height) / GlobalConstants.RandomDivider);
        }
    }
}
