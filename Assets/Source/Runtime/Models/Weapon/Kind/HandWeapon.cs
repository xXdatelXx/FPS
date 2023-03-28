using System;
using FPS.Tools;

namespace FPS.Model
{
    public sealed class HandWeapon : IWeapon
    {
        private readonly ITimer _enableTimer;
        private readonly IWeaponView _view;
        private readonly IWeapon _weapon;
        private bool _enabled;

        public HandWeapon(IWeapon weapon, ITimer enableTimer, IWeaponView view)
        {
            _weapon = weapon.ThrowExceptionIfArgumentNull(nameof(weapon));
            _enableTimer = enableTimer.ThrowExceptionIfArgumentNull(nameof(enableTimer));
            _view = view.ThrowExceptionIfArgumentNull(nameof(view));
        }

        public bool CanShoot => _weapon.CanShoot && _enabled;

        public void Shoot()
        {
            if (!CanShoot)
                throw new InvalidOperationException(nameof(Shoot));

            _weapon.Shoot();
        }

        public async void Enable()
        {
            if (_enabled)
                throw new InvalidOperationException(nameof(Enable));

            _enableTimer.Play();
            _view.Enable();

            await _enableTimer.End();

            if (_enableTimer.Canceled)
                return;

            _weapon.Enable();
            _enabled = true;
        }

        public void Disable()
        {
            if (!_enableTimer.Playing && !_enabled)
                throw new InvalidOperationException(nameof(Disable));

            if (_enableTimer.Playing)
                _enableTimer.Cancel();

            _view.Disable();
            _enabled = false;
            _weapon.Disable();
        }
    }
}