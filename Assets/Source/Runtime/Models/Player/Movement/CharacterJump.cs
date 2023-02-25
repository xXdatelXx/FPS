using System;
using Source.Runtime.Models.Movement;
using Source.Runtime.Models.Player.Movement.Interfaces;
using Source.Runtime.Tools.Extensions;
using UnityEngine;

namespace Source.Runtime.Models.Player.Movement
{
    public sealed class CharacterJump : ICharacterJump
    {
        private readonly IMovement _controller;
        private readonly AnimationCurve _motion;
        private readonly float _time;
        private float _evaluatedTime;

        public CharacterJump(IMovement controller, AnimationCurve motion)
        {
            _controller = controller.ThrowExceptionIfArgumentNull(nameof(controller));
            _motion = motion.ThrowExceptionIfArgumentNull(nameof(motion));
            _time = _motion[_motion.length - 1].time;
            
            foreach (var key in _motion.keys)
                key.value.ThrowExceptionIfValueSubZero(nameof(motion));
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
                throw new InvalidOperationException(nameof(Tick));
            
            _evaluatedTime += deltaTime;
            _controller.Move(new Vector3(0, _motion.Evaluate(_evaluatedTime / _time) * deltaTime));

            if (_evaluatedTime >= _time)
            {
                _evaluatedTime = 0;
                Jumping = false;
            }
        }
    }
}