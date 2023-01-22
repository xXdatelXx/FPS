using FPS.Model;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Source.Runtime.CompositeRoot
{
    public sealed class CharacterMovementFactory : SerializedMonoBehaviour, ICharacterMovementFactory
    {
        [SerializeField] private CharacterController _controller;
        [SerializeField] private ISpeed _speed;
        [SerializeField] private IJumpStat _jumpStat;

        public ICharacterMovement Create()
        {
            var gravitation = new CharacterGravitation(_controller);
            return new CharacterMovement(_controller, _jumpStat, gravitation, _speed);
        }
    }
}