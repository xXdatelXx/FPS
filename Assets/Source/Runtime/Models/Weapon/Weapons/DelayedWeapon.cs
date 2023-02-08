using System;
using Source.Runtime.Model.Timer;
using Source.Runtime.Tools.Extensions;

namespace FPS.Model.Weapons
{
    public sealed class DelayedWeapon : IWeapon
    {
        private readonly IWeapon _weapon;
        private readonly ITimer _delay;
        public bool CanShoot => _weapon.CanShoot && !_delay.Playing;
        public bool CanReload => _weapon.CanReload && !_delay.Playing;

        public DelayedWeapon(IWeapon weapon, ITimer delay)
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

        public void Reload()
        {
            if (!CanReload)
                throw new InvalidOperationException(nameof(Reload));
            
            _weapon.Reload();
        }

        private async void Delay()
        {
            _delay.Play();
            await _delay.End();
        }
    }
}