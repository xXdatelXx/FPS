using UnityEngine;

namespace Source.Runtime.Input
{
    //TODO переделать на input system 2.0
    public sealed class PlayerMovementInput : IPlayerMovementInput
    {
        public bool Moving => Movement() != Vector3.zero;
        public bool Rotating => Rotation() != Vector3.zero;

        public Vector3 Movement()
        {
            var x = UnityEngine.Input.GetAxis("Horizontal");
            var y = UnityEngine.Input.GetAxis("Vertical");

            return new(x, 0, y);
        }

        public Vector3 Rotation() => 
            new(-UnityEngine.Input.GetAxis("Mouse Y"), UnityEngine.Input.GetAxis("Mouse X"));

        public bool Jump() => 
            UnityEngine.Input.GetButtonDown("Jump");
    }
}