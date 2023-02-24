using Source.Runtime.Tools.Ray;
using UnityEngine;

namespace Source.Runtime.Tools.Extensions
{
    public static class RaycastExtension
    {
        public static bool Is<T>(this RaycastHit hit) => hit.collider.Is<T>();

        public static bool Is<T>(this RaycastHit hit, out IRayData<T> data)
        {
            var targetHit = hit.collider.Is(out T target);
            data = targetHit ? new RayData<T>(hit.point, hit.distance, target) : default;
            
            return targetHit;
        }
    }
}