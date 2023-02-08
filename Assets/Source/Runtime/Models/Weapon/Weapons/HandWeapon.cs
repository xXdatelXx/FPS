using System;
using Source.Runtime.Model.Timer;
using Source.Runtime.Models.Weapon.Views;
using Source.Runtime.Tools.Extensions;

namespace FPS.Model.Weapons
{
    public sealed class HandWeapon : IHandWeapon
    {
        private readonly IWeapon _weapon;
        private readonly ITimer _enableTimer;
        private readonly IHandWeaponView _view;
        private bool _enabled;
        public bool CanShoot => _weapon.CanShoot && _enabled;
        public bool CanReload => _weapon.CanReload && _enabled;

        public HandWeapon(IWeapon weapon, ITimer enableTimer, IHandWeaponView view)
        {
            _weapon = weapon.ThrowExceptionIfArgumentNull(nameof(weapon));
            _enableTimer = enableTimer.ThrowExceptionIfArgumentNull(nameof(enableTimer));
            _view = view.ThrowExceptionIfArgumentNull(nameof(view));
        }

        public void Shoot()
        {
            if (!CanShoot)
                throw new InvalidOperationException(nameof(Shoot));
            
            _weapon.Shoot();
        }

        public void Reload()
        {
            if (!CanReload)
                throw new InvalidOperationException(nameof(Reload));
            
            _weapon.Reload();
        }

        public async void Enable()
        {
            if (_enabled)
                throw new InvalidOperationException(nameof(Enable));
            
            _enableTimer.Play();
            _view.Enable();
            
            await _enableTimer.End();

            _enabled = true;
        }

        public void Disable()
        {
            if (!_enabled)
                throw new InvalidOperationException(nameof(Disable));
            
            _view.Disable();
            _enabled = false;
        }
    }
}