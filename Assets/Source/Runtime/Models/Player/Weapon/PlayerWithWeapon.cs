using Source.Runtime.Input;
using Source.Runtime.Models.Player.Weapon.Interfaces;
using Source.Runtime.Models.Weapons.Kind.Interfaces;
using Source.Runtime.Tools.Extensions;

namespace Source.Runtime.Models.Player.Weapon
{
    public sealed class PlayerWithWeapon : IPlayerWithWeapon
    {
        private readonly IPlayerWeaponInput _input;
        private readonly IWeapon _weapon;

        public PlayerWithWeapon(IWeaponWithMagazine weapon, IPlayerWeaponInput input)
        {
            _weapon = weapon.ThrowExceptionIfArgumentNull(nameof(weapon));
            _input = input.ThrowExceptionIfArgumentNull(nameof(input));
        }

        public void Tick(float deltaTime)
        {
            if (_input.Shooting && _weapon.CanShoot)
                _weapon.Shoot();
        }

        public void Enable() => _weapon.Enable();

        public void Disable() => _weapon.Disable();
    }
}