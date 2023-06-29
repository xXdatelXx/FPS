using System;
using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class CharacterMovement : ICharacterMovement
    {
        private readonly IGroundMovement _controller;
        private readonly IGravitation _gravitation;
        private readonly ICharacterJump _jump;
        private readonly float _speed;

        public CharacterMovement(IGroundMovement controller, ICharacterJump jump, IGravitation gravitation, float speed)
        {
            _controller = controller.ThrowExceptionIfArgumentNull(nameof(controller));
            _jump = jump.ThrowExceptionIfArgumentNull(nameof(jump));
            _gravitation = gravitation.ThrowExceptionIfArgumentNull(nameof(gravitation));
            _speed = speed.ThrowExceptionIfValueSubZero(nameof(speed));
        }

        public bool Jumping => _jump.Jumping;
        public bool CanJump => _jump.CanJump;

        public void Move(Vector3 direction, float deltaTime)
        {
            if (direction == Vector3.zero)
                throw new InvalidOperationException(nameof(Move));

            var motion = direction * _speed * deltaTime;

            _controller.Move(motion);
        }

        public void Jump() => _jump.Jump();

        public void Tick(float deltaTime)
        {
            _jump.Tick(deltaTime);
            if (!Jumping)
                _gravitation.Tick(deltaTime);
        }
    }
}