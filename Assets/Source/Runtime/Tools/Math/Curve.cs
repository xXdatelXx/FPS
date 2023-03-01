using UnityEngine;

namespace FPS.Tools
{
    public readonly struct Curve : ICurve
    {
        private readonly AnimationCurve _curve;

        public Curve(AnimationCurve curve)
        {
            _curve = curve.ThrowExceptionIfArgumentNull(nameof(curve));
            Time = _curve[_curve.length - 1].time;
            MaxValue = _curve[_curve.length - 1].value;
            MinValue = _curve[0].value;
        }

        public float Time { get; }
        public float MaxValue { get; }
        public float MinValue { get; }

        public float this[float time] => _curve.Evaluate(time);
    }
}