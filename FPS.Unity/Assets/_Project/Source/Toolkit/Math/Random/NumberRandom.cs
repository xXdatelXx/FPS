using System;

namespace FPS.Toolkit
{
    public sealed class NumberRandom : IRandom<int>
    {
        private readonly Range _range;
        private readonly Random _random;

        public NumberRandom(int min, int max) : this(new Range(min, max))
        { }

        public NumberRandom(Range range)
        {
            _range = range;
            _random = new();
        }

        public int Next() => 
            _random.Next((int)_range.Min, (int)_range.Max);
    }
}