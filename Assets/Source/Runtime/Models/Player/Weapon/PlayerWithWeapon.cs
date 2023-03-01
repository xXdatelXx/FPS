using FPS.Input;
using FPS.Tools;

namespace FPS.Model
{
    public sealed class PlayerWithWeapon : IPlayerWithWeapon
    {
        private readonly IPlayerWeaponInput _input;
        private readonly IWeapon _weapon;

        public PlayerWithWeapon(IWeapon weapon, IPlayerWeaponInput input)
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