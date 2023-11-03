using FPS.Data;
using FPS.GamePlay;
using FPS.Toolkit;
using FPS.Toolkit.GameLoop;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FPS.Factories
{
    public sealed class CharacterMovementFactory : SerializedMonoBehaviour, ICharacterMovementFactory
    {
        [SerializeField] private CharacterController _controller;
        [SerializeField] private CharacterConfig _config;

        public ICharacterMovement Create(IReadOnlyGameTime time)
        {
            var controller = new CharacterMovementController(_controller);
            var gravitation = new CharacterGravitation(controller, _config.Gravitation);
            var jump = new CharacterJump(controller, new Curve(_config.JumpMotion));

            return new CharacterMovement(controller, jump, gravitation, _config.Speed);
        }
    }
}