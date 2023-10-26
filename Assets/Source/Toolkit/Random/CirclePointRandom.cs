using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FPS.Toolkit
{
    public sealed class CirclePointRandom : IRandom<Vector2>
    {
        private readonly float _radius;
        private readonly float _offset;

        public CirclePointRandom(float radius, float offset)
        {
            _radius = radius.ThrowExceptionIfValueSubZero(nameof(radius));
            _offset = offset.ThrowExceptionIfValueSubZero(nameof(offset));

            if (_radius < _offset)
                throw new ArgumentOutOfRangeException("radius < offset");
        }

        public Vector2 Next() =>
            Random.insideUnitCircle.normalized * (_radius - _offset);
    }
}