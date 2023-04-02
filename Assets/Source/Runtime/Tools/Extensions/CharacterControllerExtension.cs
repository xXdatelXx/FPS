using UnityEngine;

namespace FPS.Tools
{
    public static class CharacterControllerExtension
    {
        public static Vector3 TransformDirection(this CharacterController controller, Vector3 motion) =>
            controller.transform.TransformDirection(motion);
    }
}