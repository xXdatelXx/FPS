using System;
using Cysharp.Threading.Tasks;
using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class HandWeapon : IWeapon
    {
        private readonly ITimerWithCanceling _enableTimer;
        private readonly IWeapon _weapon;

        public HandWeapon(IWeapon weapon, ITimer enableTimer) : this(weapon, new TimerWithCanceling(enableTimer))
        { }

        public HandWeapon(IWeapon weapon, ITimerWithCanceling enableTimer)
        {
            _weapon = weapon.ThrowExceptionIfArgumentNull(nameof(weapon));
            _enableTimer = enableTimer.ThrowExceptionIfArgumentNull(nameof(enableTimer));
        }

        public bool CanShoot => _weapon.CanShoot && !_enableTimer.Playing;

        public void Shoot()
        {
            if (!CanShoot)
                throw new InvalidOperationException(nameof(Shoot));

            _weapon.Shoot();
        }

        public void Enable() => EnableAsync().Forget();

        private async UniTaskVoid EnableAsync()
        {
            if (CanShoot)
                throw new InvalidOperationException(nameof(Enable));

            _enableTimer.Play();

            await _enableTimer.End();

            if (_enableTimer.Canceled)
                return;

            _weapon.Enable();
        }

        public void Disable()
        {
            _enableTimer.Cancel();
            _weapon.Disable();
        }
    }
}