using UnityEngine;

namespace FPS.Tools
{
    public static class GameObjectExtension
    {
        public static void RotateTo(this IGameObjectWithRotation gameObject, Vector3 target) => 
            gameObject.Rotate(gameObject.Rotation - target);
    }
}