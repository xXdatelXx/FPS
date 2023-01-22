using System;
using Cysharp.Threading.Tasks;
using Source.Runtime.Tools.Extensions;
using UnityEngine;

namespace FPS.Model
{
    public sealed class CharacterMovement : ICharacterMovement
    {
        private readonly CharacterController _controller;
        private readonly IJumpStat _jumpStat;
        private readonly IGravitation _gravitation;
        private readonly ISpeed _speed;
        public bool CanJump => _controller.isGrounded;

        public CharacterMovement(CharacterController controller, IJumpStat jumpStat, IGravitation gravitation, ISpeed speed)
        {
            _controller = controller.ThrowExceptionIfArgumentNull(nameof(controller));
            _jumpStat = jumpStat.ThrowExceptionIfArgumentNull(nameof(jumpStat));
            _gravitation = gravitation.ThrowExceptionIfArgumentNull(nameof(gravitation));
            _speed = speed.ThrowExceptionIfArgumentNull(nameof(speed));
        }

        public void Move(Vector3 direction, float deltaTime)
        {
            if (direction == Vector3.zero)
                throw new InvalidOperationException(nameof(Move));
            
            var motion = direction * _speed.Value;
            _controller.Move(motion * deltaTime);
        }
        
        public void Gravitate(float deltaTime) => 
            _gravitation.Gravitate(deltaTime);

        public async void Jump(float deltaTime)
        {
            if (!CanJump)
                throw new InvalidOperationException(nameof(Jump));

            var evaluatedTime = 0f;
            var time = _jumpStat.Time;

            while (evaluatedTime < time)
            {
                evaluatedTime += deltaTime;
                await UniTask.Yield();

                _controller.Move((_jumpStat.Motion * _jumpStat.Coefficient.Evaluate(evaluatedTime / time)) * deltaTime);
            }
        }
    }
}