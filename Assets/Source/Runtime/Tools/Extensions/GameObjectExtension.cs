using UnityEngine;

namespace FPS.Tools
{
    public static class GameObjectExtension
    {
        public static void RotateTo(this IGameObjectWithRotation gameObject, Vector3 target)
        {
            //  transform.rotation =
            // Quaternion.FromToRotation( inDirection, euler * Mathf.Deg2Rad ) * transform.rotation;

            //   Logger.Log(target* 90);
            // var q = 
            //    Quaternion.FromToRotation(new Vector3(0,gameObject.Rotation.y,0), target) * gameObject.Rotation;
            //Mathf.Deg2Rad
            //gameObject.Rotate(gameObject.Rotation - q);
            //var x = Quaternion.LookRotation(gameObject.Rotation, target);
            //gameObject.Rotate(gameObject.Rotation - x.eulerAngles);
            // Logger.Log(gameObject.Rotation);
            // gameObject.Rotate(gameObject.Rotation - target);
        }
    }
}