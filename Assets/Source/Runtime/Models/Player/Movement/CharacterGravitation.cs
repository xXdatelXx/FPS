using System;
using Source.Runtime.Tools.Extensions;
using UnityEngine;

namespace FPS.Model
{
    public sealed class CharacterGravitation : IGravitation
    {
        private readonly CharacterController _controller;
        private readonly Vector3 _gravityMotion;

        public CharacterGravitation(CharacterController controller, float gravityForce = 9.81f)
        {
            _controller = controller.ThrowExceptionIfArgumentNull(nameof(controller));
            _gravityMotion = new Vector3(0, -Math.Abs(gravityForce));
        }

        public void Gravitate(float deltaTime)
        {
            if (!_controller.isGrounded)
                _controller.Move(_gravityMotion * deltaTime);
        }
    }
}