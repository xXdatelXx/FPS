using UnityEngine;

namespace Source.Runtime.Tools.Extensions
{
    public static class CharacterControllerExtension
    {
        public static Vector3 TransformDirection(this CharacterController controller, Vector3 motion) =>
            controller.transform.TransformDirection(motion);
    }
}