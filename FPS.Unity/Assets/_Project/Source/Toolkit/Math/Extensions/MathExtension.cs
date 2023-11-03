using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FPS.Toolkit
{
    public static class MathExtension
    {
        public static float ClampEuler(this Mathf math, float value, float min, float max)
        {
            if (min > max)
                throw new InvalidOperationException("min > max");

            return Mathf.Clamp(value > 180 ? value - 360 : value, min, max);
        }

        public static float RandomValue(this Range range) =>
            new RationalRandom(range).Next();
    }
}