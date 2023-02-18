using Source.Runtime.Tools.Extensions;

namespace FPS.Model.Weapon
{
    public sealed class PlayerWeapons : IPlayerWeapons
    {
        private readonly IReadOnlyWeaponCollection _weapons;
        private readonly IPlayerWeaponInput _input;
        private IPlayerWeapon _weapon;

        public PlayerWeapons(IReadOnlyWeaponCollection weapons, IPlayerWeaponInput input)
        {
            _weapons = weapons.ThrowExceptionIfArgumentNull(nameof(weapons));
            _input = input.ThrowExceptionIfArgumentNull(nameof(input));
            _weapon = _weapons.Weapon;
        }

        public void Tick(float deltaTime)
        {
            _weapon.Tick(deltaTime);

            if (_input.SwitchNext && _weapons.CanSwitchNext) 
                Switch(_weapons.SwitchNext());

            if (_input.SwitchPrevious && _weapons.CanSwitchPrevious)
                Switch(_weapons.SwitchPrevious());
        }

        private void Switch(IPlayerWeapon nextWeapon)
        {
            _weapon.Disable();
            _weapon = nextWeapon;
            _weapon.Enable();
        }
    }
}