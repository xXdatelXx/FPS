using FPS.Model.Weapons;
using Source.Runtime.Tools.Extensions;

namespace FPS.Model.Weapon
{
    public sealed class PlayerWeaponWithMagazine : IPlayerWeapon
    {
        private readonly IPlayerWeaponInput _input;
        private readonly IPlayerWeapon _playerWeapon;
        private readonly IWeaponWithMagazine _weapon;

        public PlayerWeaponWithMagazine(IPlayerWeapon playerWeapon, IWeaponWithMagazine weapon, IPlayerWeaponInput input)
        {
            _playerWeapon = playerWeapon.ThrowExceptionIfArgumentNull(nameof(playerWeapon));
            _weapon = weapon.ThrowExceptionIfArgumentNull(nameof(weapon));
            _input = input.ThrowExceptionIfArgumentNull(nameof(input));
        }

        public void Tick(float deltaTime)
        {
            if (_input.Reloading && _weapon.CanReload)
                _weapon.Reload();

            _playerWeapon.Tick(deltaTime);
        }

        public void Enable() => _playerWeapon.Enable();

        public void Disable() => _playerWeapon.Disable();
    }
}