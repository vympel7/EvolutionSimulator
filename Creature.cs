using System;
using System.Collections.Generic;

namespace Evolution
{
    class Creature
    {
        const int _minLifeSpan = 10;
        const int _maxLifeSpan = 100 + 1;
        const int _minMaxStep = 1;
        const int _maxMaxStep = 10 + 1;
        const int _minEnergy = 10;
        const int _maxEnergy = 50 + 1;
        const int _minFoodRange = 1;
        const int _maxFoodRange = 20 + 1;

        int _lifeSpan, _maxStep, _energy, _foodRange;
        List<Point> _dna = new List<Point>();
        Point _position;

        public int LifeSpan { get { return _lifeSpan; } }
        public int MaxStep { get { return _maxStep; } }
        public int Energy { get { return _energy; } }
        public int FoodRange { get { return _foodRange; } }
        public List<Point> Dna { get { return _dna; } }
        public Point Position { get { return _position; } }

        public bool Dead { get { return _energy <= 0 || _lifeSpan == 0; } }


        public Creature()
        {
            float randomDivider = Useful.Divider;

            _lifeSpan = Useful.r.Next(_minLifeSpan, _maxLifeSpan);
            _maxStep = Useful.r.Next(_minMaxStep, _maxMaxStep);
            _energy = Useful.r.Next(_minEnergy, _maxEnergy);
            _foodRange = Useful.r.Next(_minFoodRange, _maxFoodRange);

            for (int _ = 0; _ < _lifeSpan; _++) _dna.Add(new Point(Useful.r.Next(-_maxStep, _maxStep) / randomDivider, Useful.r.Next(-_maxStep, _maxStep) / randomDivider));
            _position = new Point(Useful.r.Next(0, World.Width) / randomDivider, Useful.r.Next(0, World.Height) / randomDivider);
        }

        public void Eat(Food food)
        {
            _energy += food.Nutrient;
        }

        public void Move(int index)
        {
            _position.Add(_dna[index]);
            BendAround();
            _energy -= (int) Math.Abs(_dna[index].X + _dna[index].Y);
            _lifeSpan--;
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
    }
}
