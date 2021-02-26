using System;

namespace Evolution
{
    static class Food
    {
        static Random r = new Random();

        const int MaxNutrient = 2500;
        const int MinNutrient = 500;

        public static int Nutrient { get { return r.Next(MinNutrient, MaxNutrient) / GlobalConstants.RandomDivider; } }
    }
}
