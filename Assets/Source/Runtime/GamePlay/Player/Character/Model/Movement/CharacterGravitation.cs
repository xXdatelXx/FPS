using System;
using FPS.Toolkit;
using UnityEngine;

namespace FPS.Model
{
    public sealed class CharacterGravitation : IGravitation
    {
        private readonly Vector3 _gravityMotion;
        private readonly IGroundMovement _movement;

        public CharacterGravitation(IGroundMovement movement, float gravityForce = 9.81f)
        {
            _movement = movement.ThrowExceptionIfArgumentNull(nameof(movement));
            _gravityMotion = new Vector3(0, -Math.Abs(gravityForce));
        }

        public void Tick(float deltaTime)
        {
            if (!_movement.Grounded)
                _movement.Move(_gravityMotion * deltaTime);
        }
    }
}