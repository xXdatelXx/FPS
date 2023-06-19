using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class RandomRecoil : IRecoil
    {
        private readonly IRandom<Vector2> _random;

        public RandomRecoil(Range x, Range y) =>
            _random = new VectorRandom(x, y);

        public RandomRecoil(IRandom<Vector2> random) =>
            _random = random.ThrowExceptionIfArgumentNull(nameof(random));

        public Vector2 Next() => _random.Next();
    }
}