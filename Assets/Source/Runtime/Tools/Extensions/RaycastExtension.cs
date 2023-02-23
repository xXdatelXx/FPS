using UnityEngine;

namespace Source.Runtime.Tools.Extensions
{
    public static class RaycastExtension
    {
        public static bool Is<T>(this RaycastHit hit) =>
            hit.collider.GetComponent<T>() != null;
    }
}