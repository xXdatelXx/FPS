using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class DamageCoefficient : IDamageCoefficient
    {
        private readonly float _coefficient;

        public DamageCoefficient(float coefficient) =>
            _coefficient = coefficient.ThrowExceptionIfValueSubZero(nameof(coefficient));

        public float Next(float distance)
        {
            distance.ThrowExceptionIfValueSubZero(nameof(distance));
            return distance * _coefficient;
        }
    }
}