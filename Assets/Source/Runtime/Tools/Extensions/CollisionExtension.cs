using UnityEngine;

namespace Source.Runtime.Tools.Extensions
{
    public static class CollisionExtension
    {
        public static bool Is<T>(this Collider collider) =>
            GetComponent<T>(collider.gameObject) != null;

        public static bool Is<T>(this Collider collider, out T obj) =>
            collider.transform.TryGetComponent(out obj);

        public static bool Is<T>(this Collision collision) =>
            GetComponent<T>(collision.gameObject) != null;

        public static bool Is<T>(this Collision collision, out T obj) =>
            collision.transform.TryGetComponent(out obj);

        public static T GetComponent<T>(this GameObject collision) =>
            collision.transform.GetComponent<T>();
    }
}