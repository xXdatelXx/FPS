using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class RandomRecoil : IRecoil
    {
        private readonly Range _x;
        private readonly Range _y;

        public RandomRecoil(Range x, Range y) =>
            (_x, _y) = (x, y);

        public Vector2 Next() =>
            new(Random.Range(_x.Min, _x.Max), Random.Range(_y.Min, _y.Max));
    }
}