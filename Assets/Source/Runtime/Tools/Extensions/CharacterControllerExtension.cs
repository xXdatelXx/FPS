using UnityEngine;

namespace Source.Runtime.Tools.Extensions
{
    public static class CharacterControllerExtension
    {
        public static void Rotate(this CharacterController controller, Vector3 euler) =>
            controller.transform.Rotate(euler);
    }
}