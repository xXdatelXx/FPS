using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class CharacterMovementController : IGroundMovement
    {
        private readonly CharacterController _controller;

        public CharacterMovementController(CharacterController controller) =>
            _controller = controller.ThrowExceptionIfArgumentNull(nameof(controller));

        public bool Grounded => _controller.isGrounded;
        public Vector3 Position => _controller.transform.position;

        public void Move(Vector3 motion) =>
            _controller.Move(motion);

        public void MoveByRotation(Vector3 motion) =>
            Move(_controller.TransformDirection(motion));
    }
}