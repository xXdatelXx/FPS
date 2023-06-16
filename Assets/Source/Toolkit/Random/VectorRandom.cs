using UnityEngine;

namespace FPS.Toolkit
{
    public sealed class VectorRandom : IRandom<Vector2>
    {
        private readonly (IRandom<float> x, IRandom<float> y) _random;

        public VectorRandom(Range x, Range y) =>
            _random = (new RationalRandom(x), new RationalRandom(y));

        public VectorRandom(IRandom<float> x, IRandom<float> y)
        {
            _random = (
                x.ThrowExceptionIfArgumentNull(nameof(x)),
                y.ThrowExceptionIfArgumentNull(nameof(y)));
        }

        public Vector2 Next() => new Vector2(_random.x.Next(), _random.y.Next());
    }
}