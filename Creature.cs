using System;
using System.Collections.Generic;

namespace Evolution
{
    class Creature
    {
        Random r = new Random();

        const int _minLifeSpan = 10;
        const int _maxLifeSpan = 100 + 1;
        const int _minMaxStep = 1;
        const int _maxMaxStep = 10 + 1;
        const int _minEnergy = 10;
        const int _maxEnergy = 50 + 1;
        const int _minFoodRange = 1;
        const int _maxFoodRange = 20 + 1;

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
            float randomDivider = GlobalConstants.RandomDivider;

            _lifeSpan = r.Next(_minLifeSpan, _maxLifeSpan);
            _maxStep = r.Next(_minMaxStep, _maxMaxStep);
            _energy = r.Next(_minEnergy, _maxEnergy);
            _foodRange = r.Next(_minFoodRange, _maxFoodRange);

            for (int _ = 0; _ < _lifeSpan; _++) _dna.Add(new Tuple<float, float>(r.Next(0, _maxStep) / randomDivider, r.Next(0, _maxStep) / randomDivider));
            _position = new Tuple<float, float>(r.Next(0, World.Width) / randomDivider, r.Next(0, World.Height) / randomDivider);
        }

        public Creature(Tuple<float, float> position) : this()
        {
            _position = position;
        }

        public void Live(Food food, int index)
        {
            if(!Dead)
            {
                _energy += food.Nutrient;
                if (index < _dna.Count) _position = new Tuple<float, float>(_position.Item1 + _dna[index].Item1, _position.Item2 + _dna[index].Item2);
            }
        }
    }
}
