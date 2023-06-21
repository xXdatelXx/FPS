using System;
using Cysharp.Threading.Tasks;
using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class HandWeapon : IWeapon
    {
        private readonly ITimerWithCanceling _enableTimer;
        private readonly IWeaponView _view;
        private readonly IWeapon _weapon;
        private bool _enabled;

        public HandWeapon(IWeapon weapon, ITimerWithCanceling enableTimer, IWeaponView view)
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

        public void Enable()
        {
            if (_enabled)
                throw new InvalidOperationException(nameof(Enable));

            Enable().Forget();

            async UniTaskVoid Enable()
            {
                _enableTimer.Play();
                _view.Equip();
                
                await _enableTimer.End();

                if (_enableTimer.Canceled)
                    return;

                _weapon.Enable();
                _enabled = true;
            }
        }

        public void Disable()
        {
            if (!_enableTimer.Playing && !_enabled)
                throw new InvalidOperationException(nameof(Disable));

            if (_enableTimer.Playing)
                _enableTimer.Cancel();

            _view.UneQuip();
            _enabled = false;
            _weapon.Disable();
        }
    }
}