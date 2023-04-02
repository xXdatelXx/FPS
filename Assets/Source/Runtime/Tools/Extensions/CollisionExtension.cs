using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FPS.Tools
{
    public static class CollisionExtension
    {
        public static bool Is<T>(this Collider collider) =>
            collider.GetComponent<T>() != null;

        public static bool Is<T>(this Collider collider, out T obj) =>
            collider.transform.TryGetComponent(out obj);

        public static bool Is<T>(this Collision collision) =>
            collision.gameObject.GetComponent<T>() != null;

        public static bool Is<T>(this Collision collision, out T obj) =>
            collision.transform.TryGetComponent(out obj);
        
        public static bool Has<T>(this IEnumerable<T> list, T item) => 
            list.Any(i => i.Equals(item));
        
        public static IEnumerable<T> TryThrowNullReferenceForeach<T>(this IEnumerable<T> enumerable) =>
            enumerable.Select(i => i.ThrowExceptionIfNull("element is null"));
    }
}