using UnityEngine;

namespace FPS.Tools
{
    public static class RayExtension
    {
        public static float Distance<T>(this RayHit<T> hit) => 
            Vector3.Distance(hit.Points.Start, hit.Points.End);
    }
}