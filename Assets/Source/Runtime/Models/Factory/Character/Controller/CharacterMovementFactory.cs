using FPS.Model;
using Sirenix.OdinInspector;
using Source.Runtime.Models.Loop;
using UnityEngine;

namespace Source.Runtime.CompositeRoot
{
    public sealed class CharacterMovementFactory : SerializedMonoBehaviour, ICharacterMovementFactory
    {
        [SerializeField] private CharacterController _controller;
        [SerializeField] private AnimationCurve _jumpMotion;
        [SerializeField] private ISpeed _speed;

        public ICharacterMovement Create(IReadOnlyGameTime time)
        {
            var gravitation = new CharacterGravitation(_controller);
            var jump = new CharacterJump(_controller, _jumpMotion, time);

            return new CharacterMovement(_controller, jump, gravitation, _speed);
        }
    }
}