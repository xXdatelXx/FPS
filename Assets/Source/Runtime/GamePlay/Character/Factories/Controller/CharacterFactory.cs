using FPS.GamePlay;
using FPS.Toolkit.GameLoop;
using UnityEngine;

namespace FPS.Factories
{
    public sealed class CharacterFactory : MonoBehaviour, ICharacterFactory
    {
        [SerializeField] private CharacterMovementFactory _movement;
        [SerializeField] private CharacterRotationFactory _rotation;
        [SerializeField] private CharacterHealthFactory _health;

        public ICharacter Create(IReadOnlyGameTime time)
        {
            return new Character
            (
                _movement.Create(time),
                _rotation.Create(),
                _health.Create()
            );
        }
    }
}