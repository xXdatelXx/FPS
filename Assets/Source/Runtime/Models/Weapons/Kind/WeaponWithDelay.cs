using System;
using Source.Runtime.Model.Timer;
using Source.Runtime.Tools.Extensions;

namespace FPS.Model.Weapons
{
    public sealed class WeaponWithDelay : IWeapon
    {
        private readonly ITimer _delay;
        private readonly IWeapon _weapon;

        public WeaponWithDelay(IWeapon weapon, ITimer delay)
        {
            _weapon = weapon.ThrowExceptionIfArgumentNull(nameof(weapon));
            _delay = delay.ThrowExceptionIfArgumentNull(nameof(delay));
        }

        public bool CanShoot => _weapon.CanShoot && !_delay.Playing;

        public void Shoot()
        {
            if (!CanShoot)
                throw new InvalidOperationException(nameof(Shoot));

            _weapon.Shoot();
            Delay();
        }

        public void Enable() => _weapon.Enable();

        public void Disable()
        {
            _weapon.Disable();

            if (!_delay.Playing)
                _delay.Cancel();
        }

        private void Delay() => _delay.Play();
    }
}