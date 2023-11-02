using System;
using Cysharp.Threading.Tasks;
using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class WeaponWithMagazine : IWeaponWithMagazine
    {
        private readonly IWeapon _weapon;
        private readonly IMagazine _magazine;
        private readonly ITimerWithCanceling _reload;
        private bool _enabled = true;

        public WeaponWithMagazine(IWeapon weapon, IMagazine magazine, ITimerWithCanceling reloadTimer)
        {
            _weapon = weapon.ThrowExceptionIfArgumentNull(nameof(weapon));
            _magazine = magazine.ThrowExceptionIfArgumentNull(nameof(magazine));
            _reload = reloadTimer.ThrowExceptionIfArgumentNull(nameof(reloadTimer));
        }

        public bool CanShoot => _weapon.CanShoot && _magazine.CanGet && _enabled;
        public bool CanReload => _magazine.CanReload && !_reload.Playing;

        public void Shoot()
        {
            if (!CanShoot)
                throw new InvalidOperationException(nameof(Shoot));

            _magazine.Get();
            _weapon.Shoot();
        }

        public void Reload() => ReloadAsync().Forget();

        private async UniTaskVoid ReloadAsync()
        {
            if (!CanReload)
                throw new InvalidOperationException(nameof(Reload));

            _reload.Play();
            _enabled = false;

            await _reload.End();

            if (!_weapon.CanShoot)
                return;

            _magazine.Reload();
            _enabled = true;
        }

        public void Enable() => _weapon.Enable();

        public void Disable()
        {
            _weapon.Disable();

            if (_reload.Playing)
                _reload.Cancel();
        }
    }
}