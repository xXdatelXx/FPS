using FPS.Input;
using FPS.Tools;

namespace FPS.Model
{
    public sealed class PlayerWithWeapons : IPlayerWithWeapons
    {
        private readonly IPlayerWeaponInput _input;
        private readonly IWeaponCollection _weapons;
        private IPlayerWithWeapon _weapon;

        public PlayerWithWeapons(IWeaponCollection weapons, IPlayerWeaponInput input)
        {
            _weapons = weapons.ThrowExceptionIfArgumentNull(nameof(weapons));
            _input = input.ThrowExceptionIfArgumentNull(nameof(input));
            _weapon = _weapons.Weapon;
            _weapon.Enable();
        }

        public void Tick(float deltaTime)
        {
            _weapon.Tick(deltaTime);

            if (_input.SwitchNext && _weapons.CanSwitch)
                Switch(_weapons.SwitchNext());

            if (_input.SwitchPrevious && _weapons.CanSwitch)
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