using System;
using System.Collections.Generic;

namespace Evolution
{
    class World
    {
        static Random r = new Random();

        const int _minSize = 1000;
        const int _maxSize = 10000 + 1;
        const int _minFood = 50;
        const int _maxFood = 1000 + 1;

        public static int Height { get { return r.Next(_minSize, _maxSize); } }
        public static int Width { get { return r.Next(_minSize, _maxSize); } }
        public static List<Food> FoodList { get { return new List<Food>(r.Next(_minFood, _maxFood)); } }
    }
}
