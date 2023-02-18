using System;
using Source.Runtime.Tools.Extensions;
using UnityEngine;

namespace FPS.Model
{
    public sealed class CharacterMovement : ICharacterMovement
    {
        private readonly CharacterController _controller;
        private readonly IGravitation _gravitation;
        private readonly ICharacterJump _jump;
        private readonly ISpeed _speed;

        public CharacterMovement(CharacterController controller, ICharacterJump jump, IGravitation gravitation, ISpeed speed)
        {
            _controller = controller.ThrowExceptionIfArgumentNull(nameof(controller));
            _jump = jump.ThrowExceptionIfArgumentNull(nameof(jump));
            _gravitation = gravitation.ThrowExceptionIfArgumentNull(nameof(gravitation));
            _speed = speed.ThrowExceptionIfArgumentNull(nameof(speed));
        }

        public bool Jumping => _jump.Jumping;
        public bool CanJump => _jump.CanJump;
        public bool CanGravitate => _gravitation.CanGravitate && !Jumping;

        public void Move(Vector3 direction, float deltaTime)
        {
            if (direction == Vector3.zero)
                throw new InvalidOperationException(nameof(Move));

            direction = _controller.TransformDirection(direction);
            var motion = direction * _speed.Value * deltaTime;

            _controller.Move(motion);
        }

        public void Gravitate(float deltaTime) => _gravitation.Gravitate(deltaTime);
        
        public void Jump() => _jump.Jump();
    }
}