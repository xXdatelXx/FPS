using FPS.Model;
using Sirenix.OdinInspector;
using Source.Runtime.Models.Loop;
using UnityEngine;

namespace Source.Runtime.CompositeRoot
{
    public sealed class PlayerFactory : MonoBehaviour, IPlayerFactory
    {
        [SerializeField] private CharacterMovementFactory _movement;
        [SerializeField] private CharacterRotationFactory _rotation;
        [SerializeField] private CharacterHealthFactory _health;

        public IPlayer Create(IReadOnlyGameTime time)
        {
            _health.Create();
            return new Player(_movement.Create(time), _rotation.Create(), new PlayerMovementInput());
        }
    }
}