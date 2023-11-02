using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class CurveDamageCoefficient : IDamageCoefficient
    {
        private readonly Curve _curve;

        public CurveDamageCoefficient(Curve curve) =>
            _curve = curve.ThrowExceptionIfValuesSubZero(nameof(curve));

        public float Next(float distance)
        {
            distance.ThrowExceptionIfValueSubZero(nameof(distance));
            return _curve[distance];
        }
    }
}