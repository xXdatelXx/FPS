using FPS.Model;
using FPS.Model.Rotation;
using Sirenix.OdinInspector;
using Source.Runtime.CompositeRoot.Weapons;
using UnityEngine;

namespace Source.Runtime.CompositeRoot
{
    public sealed class PlayerFactory : SerializedMonoBehaviour, IPlayerFactory
    {
        [SerializeField] private ICharacterMovementFactory _movement;
        [SerializeField] private ICharacterRotationFactory _rotation;
        [SerializeField] private ICharacterWeaponFactory _weapon;
        [SerializeField] private ICharacterHealthFactory _health;

        public IPlayer Create()
        {
            _health.Create();
            return new Player(_movement.Create(), _rotation.Create(), new PlayerInput());
        }
    }
}