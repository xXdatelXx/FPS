using UnityEngine;

namespace Source.Runtime.Tools.Extensions
{
    public static class RaycastExtension
    {
        public static bool Is<T>(this RaycastHit hit) => 
            hit.collider.GetComponent<T>() != null;

        public static bool Cast<T>(this Ray ray, out T component)
        {
            if (Physics.Raycast(ray, out var hit))
                if (hit.collider.Is(out component))
                    return true;

            component = default;
            return false;
        }
    }
}