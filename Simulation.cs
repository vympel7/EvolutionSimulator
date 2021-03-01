using System;
using System.Collections.Generic;

namespace Evolution
{
    class Simulation
    {
        Random r = new Random();

        const int _minCreatures = 10;
        const int _maxCreatures = 100 + 1;

        List<Creature> _creatures;
        List<Food> _foodList;

        public List<Creature> Creatures { get { return _creatures; } }
        public List<Food> FoodList { get { return _foodList; } }


        public Simulation()
        {
            _creatures = new List<Creature>(r.Next(_minCreatures, _maxCreatures));
            _foodList = World.FoodList;

            for (int i = 0; i < _creatures.Capacity; i++) _creatures.Add(new Creature());
            for (int i = 0; i < _foodList.Capacity; i++) _foodList.Add(new Food());
        }

        public void Simulate()
        {
            int dnaIndex = 0;
            List<Tuple<Creature, Food>> ordered = FoodClosenessOrder();

            for (int i = 0; i < ordered.Count; i++)
            {
                ordered[i].Item1.Live(ordered[i].Item2, dnaIndex);
                dnaIndex++;
            }
        }

        List<Tuple<Creature, Food>> FoodClosenessOrder()
        {
            List<Tuple<Creature, Food>> order = new List<Tuple<Creature, Food>>();
            
            for (int i = 0; i < _creatures.Count; i++)
            {
                int closestIndex = -1;
                float distance = -1;
                Tuple<Creature, Food> creatureFood;

                for (int j = 0; j < _foodList.Count; j++)
                {
                    float tDistance = _creatures[i].Position.Manhattan(_foodList[j].Position);
                    if ((distance == -1 || tDistance < distance) && tDistance <= _creatures[i].FoodRange)
                    {
                        distance = tDistance;
                        closestIndex = j;
                    }
                }

                if (closestIndex != -1)
                {
                    Food closestFood = _foodList[closestIndex];
                    _foodList.RemoveAt(closestIndex);

                    creatureFood = new Tuple<Creature, Food>(_creatures[i], closestFood);
                    order.Add(creatureFood);
                }
            }

            return order;
        }
    }
}
