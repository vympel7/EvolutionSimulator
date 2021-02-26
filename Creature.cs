using System;
using System.Collections.Generic;

namespace Evolution
{
    class Creature
    {
        Random r = new Random();

        const int _minLifeSpan = 1000;
        const int _maxLifeSpan = 10000;
        const int _minMaxStep = 100;
        const int _maxMaxStep = 1000;
        const int _minEnergy = 1000;
        const int _maxEnergy = 5000;
        const int _minFoodRange = 100;
        const int _maxFoodRange = 2000;

        int _lifeSpan, _maxStep, _energy, _foodRange;
        List<Tuple<float, float>> _dna = new List<Tuple<float, float>>();
        Tuple<float, float> _position;

        public int LifeSpan { get { return _lifeSpan; } }
        public int MaxStep { get { return _maxStep; } }
        public int Energy { get { return _energy; } }
        public int FoodRange { get { return _foodRange; } }
        public List<Tuple<float, float>> Dna { get { return _dna; } }
        public Tuple<float, float> Position { get { return _position; } }

        public bool Dead { get { return _energy == 0 || _lifeSpan == 0; } }


        public Creature()
        {
            int randomDivider = GlobalConstants.RandomDivider;

            _lifeSpan = r.Next(_minLifeSpan, _maxLifeSpan) / randomDivider;
            _maxStep = r.Next(_minMaxStep, _maxMaxStep) / randomDivider;
            _energy = r.Next(_minEnergy, _maxEnergy) / randomDivider;
            _foodRange = r.Next(_minFoodRange, _maxFoodRange) / randomDivider;
            
            for (int _ = 0; _ < _lifeSpan; _++) _dna.Add(new Tuple<float, float>(r.Next(0, _maxStep) / randomDivider, r.Next(0, _maxStep) / randomDivider));
            _position = new Tuple<float, float>(r.Next(0, World.Width), r.Next(0, World.Height));
        }

        public Creature(Tuple<float, float> position) : this()
        {
            _position = position;
        }
    }
}
