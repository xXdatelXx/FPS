using FPS.Tools;

namespace FPS.Model
{
    public sealed class DamagePolicy : IDamagePolicy
    {
        private readonly IDamageCoefficient _coefficient;

        public DamagePolicy(IDamageCoefficient coefficient) =>
            _coefficient = coefficient.ThrowExceptionIfArgumentNull(nameof(coefficient));

        public float Affect(float damage, float distance)
        {
            distance.ThrowExceptionIfValueSubZero(nameof(distance));

            if (distance == 0)
                distance = 1;

            var coefficient = _coefficient.Get(distance).ThrowExceptionIfValueSubZero(nameof(_coefficient));
            return damage / coefficient;
        }
    }
}