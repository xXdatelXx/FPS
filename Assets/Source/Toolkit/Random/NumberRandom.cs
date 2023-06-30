using UnityEngine;

namespace FPS.Toolkit
{
    public sealed class NumberRandom : IRandom<int>
    {
        private readonly Range _range;

        public NumberRandom(float min, float max) : this(new Range(min, max))
        { }

        public NumberRandom(Range range) => _range = range;

        public int Next() => (int)Random.Range(_range.Min, _range.Max);
    }
}