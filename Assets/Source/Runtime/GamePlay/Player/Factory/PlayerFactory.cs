using FPS.Input;
using FPS.GamePlay;
using FPS.Toolkit.GameLoop;
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
            return new Player
            (
                new Character
                (
                    _movement.Create(time),
                    _rotation.Create(),
                    _health.Create()
                ),
                new PlayerMovementInput()
            );
        }
    }
}