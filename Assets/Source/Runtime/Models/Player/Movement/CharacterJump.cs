using System;
using Cysharp.Threading.Tasks;
using Source.Runtime.Models.Loop;
using Source.Runtime.Tools.Extensions;
using UnityEngine;

namespace FPS.Model
{
    public sealed class CharacterJump : ICharacterJump
    {
        private readonly CharacterController _controller;
        private readonly AnimationCurve _motion;
        private readonly IReadOnlyGameTime _gameTime;
        public bool Jumping { get; private set; }
        public bool CanJump => _controller.isGrounded;

        public CharacterJump(CharacterController controller, AnimationCurve motion, IReadOnlyGameTime gameTime)
        {
            _controller = controller.ThrowExceptionIfArgumentNull(nameof(controller));
            _gameTime = gameTime.ThrowExceptionIfArgumentNull(nameof(gameTime));
            _motion = motion.ThrowExceptionIfArgumentNull(nameof(motion));
            foreach (var key in _motion.keys) 
                key.value.ThrowExceptionIfValueSubZero(nameof(motion));
        }

        public async void Jump()
        {
            if (!CanJump)
                throw new InvalidOperationException(nameof(Jump));

            Jumping = true;
            var evaluatedTime = 0f;
            var time = _motion[_motion.length - 1].time;

            while (evaluatedTime < time)
            {
                evaluatedTime += _gameTime.Delta;
                await UniTask.Yield();

                _controller.Move(new Vector3(0, _motion.Evaluate(evaluatedTime / time) * _gameTime.Delta));
            }

            Jumping = false;
        }
    }
}