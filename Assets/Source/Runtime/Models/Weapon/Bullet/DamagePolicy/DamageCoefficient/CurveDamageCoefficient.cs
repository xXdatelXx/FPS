using FPS.Tools;

namespace FPS.Model
{
    public sealed class CurveDamageCoefficient : IDamageCoefficient
    {
        private readonly Curve _curve;

        public CurveDamageCoefficient(Curve curve)
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