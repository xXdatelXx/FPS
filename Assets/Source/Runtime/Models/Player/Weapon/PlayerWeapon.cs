using FPS.Model.Weapons;
using Source.Runtime.Tools.Extensions;

namespace FPS.Model.Weapon
{
    public sealed class PlayerWeapon : IPlayerWeapon
    {
        private readonly IReadOnlyWeaponCollection<IHandWeapon> _weapons;
        private readonly IPlayerWeaponInput _input;
        private IHandWeapon _weapon;

        public PlayerWeapon(IReadOnlyWeaponCollection<IHandWeapon> weapons, IPlayerWeaponInput input)
        {
            _weapons = weapons.ThrowExceptionIfArgumentNull(nameof(weapons));
            _input = input.ThrowExceptionIfArgumentNull(nameof(input));
            _weapon = _weapons.Weapon;
            _weapon.Enable();
        }

        public void Tick(float deltaTime)
        {
            if (_input.Shooting && _weapon.CanShoot) 
                _weapon.Shoot();

            if (_input.Reloading && _weapon.CanReload)
                _weapon.Reload();

            if (_input.SwitchNext && _weapons.CanSwitchNext) 
                Switch(_weapons.SwitchNext());

            if (_input.SwitchPrevious && _weapons.CanSwitchPrevious)
                Switch(_weapons.SwitchPrevious());
        }

        private void Switch(IHandWeapon nextWeapon)
        {
            _weapon.Disable();
            _weapon = nextWeapon;
            _weapon.Enable();
        }
    }
}