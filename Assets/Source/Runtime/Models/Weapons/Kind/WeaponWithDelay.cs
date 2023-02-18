using System;
using Source.Runtime.Model.Timer;
using Source.Runtime.Tools.Extensions;

namespace FPS.Model.Weapons
{
    public sealed class WeaponWithDelay : IWeapon
    {
        private readonly IWeapon _weapon;
        private readonly ITimer _delay;
        public bool CanShoot => _weapon.CanShoot && !_delay.Playing;

        public WeaponWithDelay(IWeapon weapon, ITimer delay)
        {
            _weapon = weapon.ThrowExceptionIfArgumentNull(nameof(weapon));
            _delay = delay.ThrowExceptionIfArgumentNull(nameof(delay));
        }

        public void Shoot()
        {
            if (!CanShoot)
                throw new InvalidOperationException(nameof(Shoot));

            _weapon.Shoot();
            Delay();
        }

        private void Delay() => _delay.Play();

        public void Enable() => _weapon.Enable();

        public void Disable()
        {
            _weapon.Disable();
            
            if (!_delay.Playing)
                _delay.Cancel();
        }
    }
}