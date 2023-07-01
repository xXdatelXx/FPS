using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class CharacterMovementController : IGroundMovement
    {
        private readonly CharacterController _controller;

        public CharacterMovementController(CharacterController controller)
        {
            _controller = controller.ThrowExceptionIfArgumentNull(nameof(controller));
            Position = new Position(controller.transform);
        }

        public bool Grounded => _controller.isGrounded;
        public IReadOnlyPosition Position { get; }

        public void Move(Vector3 motion) =>
            _controller.Move(_controller.TransformDirection(motion));
    }
}