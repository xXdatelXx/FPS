using System;
using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class CharacterJump : ICharacterJump
    {
        private readonly IGroundMovement _controller;
        private readonly ICurve _motion;
        private float _evaluatedTime;

        public CharacterJump(IGroundMovement controller, ICurve motion)
        {
            _controller = controller.ThrowExceptionIfArgumentNull(nameof(controller));
            _motion = motion
                .ThrowExceptionIfArgumentNull(nameof(motion))
                .ThrowExceptionIfValuesSubZero(nameof(motion));
        }

        public bool Jumping { get; private set; }
        public bool CanJump => _controller.Grounded;

        public void Jump()
        {
            if (!CanJump)
                throw new InvalidOperationException(nameof(Jump));

            Jumping = true;
        }

        public void Tick(float deltaTime)
        {
            if (!Jumping)
                return;

            _evaluatedTime += deltaTime;
            var motion = _motion[_evaluatedTime / _motion.Time];
            _controller.Move(new Vector3(0, motion * deltaTime));

            if (_evaluatedTime >= _motion.Time)
            {
                _evaluatedTime = 0;
                Jumping = false;
            }
        }
    }
}