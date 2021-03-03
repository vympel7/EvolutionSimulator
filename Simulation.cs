using System;
using System.Collections.Generic;

namespace Evolution
{
    class Simulation
    {
        Random r = new Random();

        const int _minCreatures = 10;
        const int _maxCreatures = 100 + 1;
        const int _minEpochDuration = 50;
        const int _maxEpochDuration = 150 + 1;

        List<Creature> _creatures;
        List<Food> _foodList = World.FoodList;

        public List<Creature> Creatures { get { return _creatures; } }
        public List<Food> FoodList { get { return _foodList; } }


        public Simulation()
        {
            int nCreatures = r.Next(_minCreatures, _maxCreatures);
            _creatures = new List<Creature>(nCreatures);

            for (int i = 0; i < _creatures.Capacity; i++) _creatures.Add(new Creature());
            for (int i = 0; i < _foodList.Capacity; i++) _foodList.Add(new Food());

            Console.WriteLine($"World width: {World.Width}\nWorld height: {World.Height}");
            Console.WriteLine($"Number of creatures: {nCreatures}");
        }

        public void Simulate(int epochs, int epochDuration = -1, bool debug = false)
        {
            epochDuration = epochDuration == -1 ? r.Next(_minEpochDuration, _maxEpochDuration) : epochDuration;

            for (int e = 0; e < epochs; e++)
            {
                Console.WriteLine(new string('-', 50));
                DebugInfo("\nBefore generation", debug);
                
                Console.WriteLine($"\nExecuting Generation {e+1}...\n");

                Generation generation = new Generation(_creatures, _foodList, epochDuration);

                generation.Execute();

                _creatures = generation.Creatures;
                _foodList = generation.FoodList;

                DebugInfo("After generation", debug);
                Console.WriteLine(new string('-', 50));
                Console.WriteLine();
            }
        }

        void DebugInfo(string message, bool debug)
        {
            Console.WriteLine(message);
            if (debug)
            {
                Console.WriteLine($"Alive: {_creatures.Count}");
                for (int i = 0; i < _creatures.Count; i++)
                {
                    Console.WriteLine($"\nIndex {i}");
                    Console.WriteLine($"Position: {_creatures[i].Position}");
                    Console.WriteLine($"Energy: {_creatures[i].Energy}");
                    Console.WriteLine($"Lifespan: {_creatures[i].LifeSpan}\n");
                }
            }
        }
    }
}
