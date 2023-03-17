using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class CharacterMovementController : IMovement
    {
        private readonly CharacterController _controller;

        public CharacterMovementController(CharacterController controller) =>
            _controller = controller.ThrowExceptionIfArgumentNull(nameof(controller));

        public bool Grounded => _controller.isGrounded;

        public void Move(Vector3 motion) =>
            _controller.Move(motion);

        public void MoveByRotation(Vector3 motion) =>
            Move(_controller.TransformDirection(motion));
    }
}