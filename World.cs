using System;
using System.Collections.Generic;

namespace Evolution
{
    class World
    {
        const int _minSize = 1000;
        const int _maxSize = 10000 + 1;
        const int _minFood = 50;
        const int _maxFood = 1000 + 1;

        static int _xSize = Useful.r.Next(_minSize, _maxSize);
        static int _ySize = Useful.r.Next(_minSize, _maxSize);

        public static int Height { get { return _xSize; } }
        public static int Width { get { return _ySize; } }
        public static List<Food> FoodList { get { return new List<Food>(Useful.r.Next(_minFood, _maxFood)); } }
    }
}
