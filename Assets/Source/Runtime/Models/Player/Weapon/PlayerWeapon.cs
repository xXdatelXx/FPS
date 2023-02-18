using FPS.Model.Weapons;
using Source.Runtime.Tools.Extensions;

namespace FPS.Model.Weapon
{
    public sealed class PlayerWeapon : IPlayerWeapon
    {
        private readonly IPlayerWeaponInput _input;
        private readonly IWeapon _weapon;

        public PlayerWeapon(IWeaponWithMagazine weapon, IPlayerWeaponInput input)
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