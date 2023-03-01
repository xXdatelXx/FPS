using FPS.Game;
using FPS.Input;
using FPS.Model;
using UnityEngine;

namespace FPS.Factories
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