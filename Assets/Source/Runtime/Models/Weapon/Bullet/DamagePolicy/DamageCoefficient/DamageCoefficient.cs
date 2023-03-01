using FPS.Tools;

namespace FPS.Model
{
    public sealed class DamageCoefficient : IDamageCoefficient
    {
        private readonly float _coefficient;

        public DamageCoefficient(float coefficient) =>
            _coefficient = coefficient.ThrowExceptionIfValueSubZero(nameof(coefficient));

        public float Get(float distance)
        {
            distance.ThrowExceptionIfValueSubZero(nameof(distance));
            return distance * _coefficient;
        }
    }
}