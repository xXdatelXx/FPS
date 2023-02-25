using Source.Runtime.Tools.Extensions;
using Source.Runtime.Tools.Math;
using UnityEngine;

namespace Source.Runtime.Models.Weapons.Bullet
{
    public sealed class CurveDamageCoefficient : IDamageCoefficient
    {
        private readonly ICurve _curve;

        public CurveDamageCoefficient(ICurve curve)
        {
            _curve = curve
                .ThrowExceptionIfArgumentNull(nameof(curve))
                .ThrowExceptionIfValuesSubZero(nameof(curve));
        }

        public float Get(float distance)
        {
            distance.ThrowExceptionIfValueSubZero(nameof(distance));
            return _curve[distance];
        }
    }
}