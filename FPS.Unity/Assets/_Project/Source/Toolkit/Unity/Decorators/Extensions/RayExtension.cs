using UnityEngine;

namespace FPS.Toolkit
{
    public static class RayExtension
    {
        public static float Distance<TTarget>(this RayHit<TTarget> hit) =>
            Vector3.Distance(hit.Points.Start, hit.Points.End);

        public static TTarget GetComponent<TTarget>(this RaycastHit hit) =>
            hit.collider.GetComponent<TTarget>();
    }
}