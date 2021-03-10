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

        /// <summary>
        /// Executes a generation
        /// </summary>
        public void Execute()
        {
            for (int index = 0; index < _epochDuration; index++)
            {                
                List<Tuple<Creature, Food>> eatingOrder = FoodClosenessOrder();

                for (int i = 0; i < eatingOrder.Count; i++)
                {
                    eatingOrder[i].Item1.Eat(eatingOrder[i].Item2);
                }

                for (int i = 0; i < _creatures.Count; i++)
                {
                    _creatures[i].Move(index);
                }

                _creatures.RemoveAll(c => c.Dead);
            }

            List<Tuple<Creature, Creature>> matingOrder = MatingOrder();

            for (int i = 0; i < matingOrder.Count; i++)
            {
                Creature newCreature = matingOrder[i].Item1.Mate(matingOrder[i].Item2);
                _creatures.Add(newCreature);
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

        List<Tuple<Creature, Creature>> MatingOrder()
        {
            List<Creature> copyCreatures = new List<Creature>(_creatures);

            List<Tuple<Creature, Creature>> order = new List<Tuple<Creature, Creature>>();

            for (int i = 0; i < _creatures.Count; i++)
            {
                int closestIndex = Useful.Invalid;
                float distance = Useful.Invalid;
                Tuple<Creature, Creature> mates;

                for (int j = 0; j < copyCreatures.Count; j++)
                {
                    float tDistance = _creatures[i].Position.Manhattan(copyCreatures[j].Position);
                    if ((distance == Useful.Invalid || tDistance < distance) && (tDistance <= _creatures[i].MatingRange && tDistance <= copyCreatures[j].MatingRange))
                    {
                        distance = tDistance;
                        closestIndex = j;
                    }
                }

                if (closestIndex != Useful.Invalid)
                {
                    Creature closestCreature = copyCreatures[closestIndex];
                    copyCreatures.RemoveAt(closestIndex);

                    mates = new Tuple<Creature, Creature>(_creatures[i], closestCreature);
                    order.Add(mates);
                }
            }

            return order;
        }

    }
}
