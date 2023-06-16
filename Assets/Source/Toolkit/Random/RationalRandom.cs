using UnityEngine;

namespace FPS.Toolkit
{
    public sealed class RationalRandom : IRandom<float>
    {
        private readonly Range _range;

        public RationalRandom(float min, float max) : this(new Range(min, max))
        { }

        public RationalRandom(Range range) => _range = range;

        public float Next() => Random.Range(_range.Min, _range.Max);
    }
}