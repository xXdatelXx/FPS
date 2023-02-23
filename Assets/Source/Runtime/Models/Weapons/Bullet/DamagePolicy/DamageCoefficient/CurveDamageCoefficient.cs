using Source.Runtime.Tools.Extensions;
using UnityEngine;

namespace Source.Runtime.Models.Weapons.Bullet
{
    public sealed class CurveDamageCoefficient : IDamageCoefficient
    {
        private readonly AnimationCurve _curve;

        public CurveDamageCoefficient(AnimationCurve curve) =>
            _curve = curve.ThrowExceptionIfArgumentNull(nameof(curve));

        public float Get(float distance)
        {
            distance.ThrowExceptionIfValueSubZero(nameof(distance));
            return _curve.Evaluate(distance);
        }
    }
}