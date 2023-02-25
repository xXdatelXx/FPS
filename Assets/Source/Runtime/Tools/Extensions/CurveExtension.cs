using Source.Runtime.Tools.Math;
using UnityEngine;

namespace Source.Runtime.Tools.Extensions
{
    public static class CurveExtension
    {
        public static AnimationCurve ThrowExceptionIfValuesSubZero(this AnimationCurve curve, string name = nameof(Curve))
        {
            for (float i = 0; i < curve[curve.length - 1].time; i += Time.fixedTime)
                curve.Evaluate(i).ThrowExceptionIfValueSubZero(name);

            return curve;
        }

        public static ICurve ThrowExceptionIfValuesSubZero(this ICurve curve, string name = nameof(Curve))
        {
            for (float i = 0; i < curve.Time; i += Time.fixedTime)
                curve[i].ThrowExceptionIfValueSubZero(name);

            return curve;
        }
    }
}