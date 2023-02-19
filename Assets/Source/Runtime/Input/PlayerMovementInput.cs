using UnityEngine;

namespace FPS.Model
{
    //TODO переделать на input system 2.0
    public sealed class PlayerMovementInput : IPlayerMovementInput
    {
        public bool Moving => Movement() != Vector3.zero;
        public bool Rotating => Rotation() != Vector3.zero;

        public Vector3 Movement()
        {
            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");

            return new(x, 0, y);
        }

        public Vector3 Rotation() => 
            new(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));

        public bool Jump() => 
            Input.GetButtonDown("Jump");
    }
}