using FPS.Model;
using Sirenix.OdinInspector;
using Source.Runtime.Models.Loop;
using UnityEngine;

namespace Source.Runtime.CompositeRoot
{
    public sealed class PlayerFactory : SerializedMonoBehaviour, IPlayerFactory
    {
        [SerializeField] private ICharacterMovementFactory _movement;
        [SerializeField] private ICharacterRotationFactory _rotation;
        [SerializeField] private ICharacterHealthFactory _health;

        public IPlayer Create(IReadOnlyGameTime time)
        {
            _health.Create();
            return new Player(_movement.Create(time), _rotation.Create(), new PlayerMovementInput());
        }
    }
}