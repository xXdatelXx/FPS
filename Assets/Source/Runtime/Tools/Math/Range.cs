using System;

namespace Source.Runtime.Tools.Math
{
    public struct Range
    {
        public readonly float Min;
        public readonly float Max;

        public Range(float min, float max)
        {
            if(max < min)
                throw new ArgumentException("max < min");

            (Max, Min) = (max, min);
        }
    }
}