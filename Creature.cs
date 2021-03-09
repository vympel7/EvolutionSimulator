using System;
using System.Collections.Generic;
using System.Text;

namespace Evolution
{
    class Creature
    {
        const int _minLifeSpan = 10;
        const int _maxLifeSpan = 150 + 1;
        const int _minMaxStep = 1;
        const int _maxMaxStep = 10 + 1;
        const int _minEnergy = 10;
        const int _maxEnergy = 50 + 1;
        const int _minFoodRange = 1;
        const int _maxFoodRange = 20 + 1;
        const int _minMatingRange = 20;
        const int _maxMatingRange = 50 + 1;

        int _lifeSpan, _maxStep, _energy, _foodRange, _matingRange;
        List<Point> _dna = new List<Point>();
        Point _position;

        public int LifeSpan { get { return _lifeSpan; } }
        public int MaxStep { get { return _maxStep; } }
        public int Energy { get { return _energy; } }
        public int FoodRange { get { return _foodRange; } }
        public int MatingRange { get { return _matingRange; } }
        public List<Point> Dna { get { return _dna; } }
        public Point Position { get { return _position; } }

        public bool Dead { get { return _energy <= 0 || _lifeSpan == 0; } }


        public Creature()
        {
            float randomDivider = Useful.Divider;

            _lifeSpan = Useful.Rand.Next(_minLifeSpan, _maxLifeSpan);
            _maxStep = Useful.Rand.Next(_minMaxStep, _maxMaxStep);
            _energy = Useful.Rand.Next(_minEnergy, _maxEnergy);
            _foodRange = Useful.Rand.Next(_minFoodRange, _maxFoodRange);
            _matingRange = Useful.Rand.Next(_minMatingRange, _maxMatingRange);

            for (int _ = 0; _ < _lifeSpan; _++) _dna.Add(new Point(Useful.Rand.Next(-_maxStep, _maxStep) / randomDivider, Useful.Rand.Next(-_maxStep, _maxStep) / randomDivider));
            _position = new Point();
        }

        public Creature(int lifespan, int maxStep, int energy, int foodRange, int matingRange, List<Point> dna)
        {
            _lifeSpan = lifespan;
            _maxStep = maxStep;
            _energy = energy;
            _foodRange = foodRange;
            _matingRange = matingRange;
            _dna = dna;
            _position = new Point();
        }


        public void Eat(Food food)
        {
            _energy += food.Nutrient;
        }

        public void Move(int index)
        {
            _position.Add(_dna[index]);
            BendAround();
            _energy -= (int)Math.Abs(_dna[index].X + _dna[index].Y);
            _lifeSpan--;
        }

        public Creature Mate(Creature other)
        {
            int minX = 0;
            int maxX = 1;

            int x = Useful.Rand.Next(minX, maxX);

            int newLifeSpan = (int)Math.Round(Useful.Lerp(x, minX, maxX, _lifeSpan, other.LifeSpan));
            int newMaxStep = (int)Math.Round(Useful.Lerp(x, minX, maxX, _maxStep, other.MaxStep));
            int newEnergy = (int)Math.Round(Useful.Lerp(x, minX, maxX, _energy, other.Energy));
            int newFoodRange = (int)Math.Round(Useful.Lerp(x, minX, maxX, _foodRange, other.FoodRange));
            int newMatingRange = (int)Math.Round(Useful.Lerp(x, minX, maxX, _matingRange, other.MatingRange));

            List<Point> newDna = new List<Point>(newLifeSpan);
            for (int i = 0; i < _lifeSpan; i++)
            {
                float dnaX = Useful.Lerp(x, minX, maxX, _dna[i].X, other.Dna[i].X);
                float dnaY = Useful.Lerp(x, minX, maxX, _dna[i].Y, other.Dna[i].Y);
                newDna.Add(new Point(dnaX, dnaY));
            }
            for (int i = 0; i < newLifeSpan - _lifeSpan; i++) newDna.Add(new Point(Useful.Rand.Next(-newMaxStep, newMaxStep) / Useful.Divider, Useful.Rand.Next(-newMaxStep, newMaxStep) / Useful.Divider));


            Creature newBorn = new Creature(newLifeSpan, newMaxStep, newEnergy, newFoodRange, newMatingRange, newDna);
            /*
             * random between -1 and 1 (-10 and 10 divided)
             * 0 get from this creature
             * 1 get from other creature
             * 0.5 get average from both
             * 
             * 0 -> 0.5 average but more similar to this
             * 0.5 -> 1 average but more similar to other
             * 
             * 0 <= x <= 1
             */
            return newBorn;
        }

        void BendAround()
        {
            float xOffset = _position.X - World.Width;
            float yOffset = _position.Y - World.Height;
            if (xOffset > 0) _position.X = xOffset;
            else if (xOffset < -World.Width) _position.X = World.Width - (xOffset + World.Width);
            if (xOffset > 0) _position.Y = yOffset;
            else if (yOffset < -World.Height) _position.Y = World.Height - (yOffset + World.Height);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Position: {_position}\nEnergy: { _energy}\nLifespan: {_lifeSpan}\n");
            return sb.ToString();
        }
    }
}
