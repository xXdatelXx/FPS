using Source.Runtime.Input;
using Source.Runtime.Models.Player.Weapon.Interfaces;
using Source.Runtime.Tools.Extensions;

namespace Source.Runtime.Models.Player.Weapon
{
    public sealed class PlayerWithWeapons : IPlayerWithWeapons
    {
        private readonly IPlayerWeaponInput _input;
        private readonly IReadOnlyWeaponCollection _weapons;
        private IPlayerWithWeapon _weapon;

        public PlayerWithWeapons(IReadOnlyWeaponCollection weapons, IPlayerWeaponInput input)
        {
            _weapons = weapons.ThrowExceptionIfArgumentNull(nameof(weapons));
            _input = input.ThrowExceptionIfArgumentNull(nameof(input));
            _weapon = _weapons.Weapon;
            _weapon.Enable();
        }

        public void Tick(float deltaTime)
        {
            _weapon.Tick(deltaTime);

            if (_input.SwitchNext && _weapons.CanSwitchNext)
                Switch(_weapons.SwitchNext());

            if (_input.SwitchPrevious && _weapons.CanSwitchPrevious)
                Switch(_weapons.SwitchPrevious());
        }

        private void Switch(IPlayerWithWeapon nextWeapon)
        {
            _weapon.Disable();
            _weapon = nextWeapon;
            _weapon.Enable();
        }
    }
}