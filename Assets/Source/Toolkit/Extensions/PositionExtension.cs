using UnityEngine;

namespace FPS.Toolkit
{
    public static class PositionExtension
    {
        public static bool IsSame(this IReadOnlyPosition a, IReadOnlyPosition b) =>
            a.Value == b.Value;

        public static float Distance(this IReadOnlyPosition a, IReadOnlyPosition b) =>
            Distance(a, b.Value);

        public static float Distance(this IReadOnlyPosition a, Vector3 b)
            => Vector3.Distance(a.Value, b);
    }
}