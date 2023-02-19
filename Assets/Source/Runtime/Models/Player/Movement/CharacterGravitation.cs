using System;
using Source.Runtime.Models.Movement;
using Source.Runtime.Models.Player.Movement.Interfaces;
using Source.Runtime.Tools.Extensions;
using UnityEngine;

namespace Source.Runtime.Models.Player.Movement
{
    public sealed class CharacterGravitation : IGravitation
    {
        private readonly IMovement _controller;
        private readonly Vector3 _gravityMotion;

        public CharacterGravitation(IMovement controller, float gravityForce = 9.81f)
        {
            _controller = controller.ThrowExceptionIfArgumentNull(nameof(controller));
            _gravityMotion = new Vector3(0, -Math.Abs(gravityForce));
        }

        public bool CanGravitate => !_controller.Grounded;

        public void Gravitate(float deltaTime)
        {
            if (!CanGravitate)
                throw new InvalidOperationException(nameof(Gravitate));

            _controller.Move(_gravityMotion * deltaTime);
        }
    }
}