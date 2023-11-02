using System;

namespace FPS.Toolkit
{
    public sealed class RationalRandom : IRandom<float>
    {
        private readonly Range _range;
        private readonly Random _random;

        public RationalRandom(float min, float max) : this(new Range(min, max))
        { }

        public RationalRandom(Range range)
        {
            _range = range;
            _random = new Random();
        }

        public float Next()
        {
            double coefficient = _random.NextDouble();
            double value = coefficient * _range.Delta + _range.Min;
            
            return (float)value;
        }
    }
}