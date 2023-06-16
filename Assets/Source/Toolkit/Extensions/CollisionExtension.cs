using UnityEngine;

namespace FPS.Toolkit
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
    }
}