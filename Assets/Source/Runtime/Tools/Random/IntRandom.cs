using UnityEngine;

namespace FPS.Tools
{
    public sealed class IntRandom : IRandom<int>
    {
        private readonly Range _range;

        public IntRandom(int min, int max) : this(new Range(min, max))
        { }

        public IntRandom(Range range) => _range = range;

        public int Next() => (int)Random.Range(_range.Min, _range.Max);
    }
}