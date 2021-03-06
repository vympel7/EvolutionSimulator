using System;
using System.Collections.Generic;

namespace Evolution
{
    class Generation
    {
        int _epochDuration;
        List<Creature> _creatures;
        List<Food> _foodList;

        public List<Creature> Creatures { get { return _creatures; } }
        public List<Food> FoodList { get { return _foodList; } }

        public Generation(List<Creature> creatures, List<Food> foodList, int epochDuration)
        {
            _creatures = creatures;
            _foodList = foodList;
            _epochDuration = epochDuration;
        }

        public void Execute()
        {
            for(int index = 0; index < _epochDuration; index++)
            {
                _creatures.RemoveAll(c => c.Dead);

                List<Tuple<Creature, Food>> ordered = FoodClosenessOrder();

                for (int i = 0; i < ordered.Count; i++)
                {
                    ordered[i].Item1.Eat(ordered[i].Item2);
                }

                for (int i = 0; i < _creatures.Count; i++)
                {
                    _creatures[i].Move(index);
                }

                _creatures.RemoveAll(c => c.Dead);
            }
        }

        List<Tuple<Creature, Food>> FoodClosenessOrder()
        {
            List<Tuple<Creature, Food>> order = new List<Tuple<Creature, Food>>();

            for (int i = 0; i < _creatures.Count; i++)
            {
                int closestIndex = Useful.Invalid;
                float distance = Useful.Invalid;
                Tuple<Creature, Food> creatureFood;

                for (int j = 0; j < _foodList.Count; j++)
                {
                    float tDistance = _creatures[i].Position.Manhattan(_foodList[j].Position);
                    if ((distance == Useful.Invalid || tDistance < distance) && tDistance <= _creatures[i].FoodRange)
                    {
                        distance = tDistance;
                        closestIndex = j;
                    }
                }

                if (closestIndex != Useful.Invalid)
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
