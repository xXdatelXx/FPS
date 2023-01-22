using UnityEngine;

namespace FPS.Model
{
    // переделаю на новой input system
    public sealed class PlayerInput : IPlayerInput
    {
        public bool Moving => Movement() != Vector3.zero;
        public bool Rotating => Rotation() != Vector3.zero;

        public Vector3 Movement()
        {
            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");
            return new(-y, 0, x);
        }

        public Vector3 Rotation() =>
            new(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));

        public bool Jump() =>
            Input.GetButtonDown("Jump");
    }
}