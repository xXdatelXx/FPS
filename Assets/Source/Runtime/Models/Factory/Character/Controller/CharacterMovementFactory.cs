using Sirenix.OdinInspector;
using Source.Runtime.Models.Game.Loop.Time;
using Source.Runtime.Models.Movement;
using Source.Runtime.Models.Player.Movement;
using Source.Runtime.Models.Player.Movement.Interfaces;
using Source.Runtime.Tools.Math;
using UnityEngine;

namespace Source.Runtime.Models.Factory.Character.Controller
{
    public sealed class CharacterMovementFactory : SerializedMonoBehaviour, ICharacterMovementFactory
    {
        [SerializeField] private CharacterController _controller;
        [SerializeField] private AnimationCurve _jumpMotion;
        [SerializeField] private ISpeed _speed;

        public ICharacterMovement Create(IReadOnlyGameTime time)
        {
            var controller = new CharacterMovementController(_controller);
            var gravitation = new CharacterGravitation(controller);
            var jump = new CharacterJump(controller, new Curve(_jumpMotion));

            return new CharacterMovement(controller, jump, gravitation, _speed);
        }
    }
}