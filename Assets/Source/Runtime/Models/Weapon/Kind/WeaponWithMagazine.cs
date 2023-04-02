using System;
using FPS.Tools;

namespace FPS.Model
{
    public sealed class WeaponWithMagazine : IWeaponWithMagazine
    {
        private readonly IMagazine _magazine;
        private readonly ITimer _reloadTimer;
        private readonly IWeaponView _view;
        private readonly IWeapon _weapon;
        private bool _enabled;

        public WeaponWithMagazine(IWeapon weapon, IMagazine magazine, ITimer reloadTimer) 
            : this(weapon, magazine, reloadTimer, new NullWeaponView())
        { }

        public WeaponWithMagazine(IWeapon weapon, IMagazine magazine, ITimer reloadTimer, IWeaponView view)
        {
            _weapon = weapon.ThrowExceptionIfArgumentNull(nameof(weapon));
            _magazine = magazine.ThrowExceptionIfArgumentNull(nameof(magazine));
            _reloadTimer = reloadTimer.ThrowExceptionIfArgumentNull(nameof(reloadTimer));
            _view = view.ThrowExceptionIfArgumentNull(nameof(view));
        }

        public bool CanShoot => _weapon.CanShoot && !_reloadTimer.Playing && _magazine.CanGet && _enabled;
        public bool CanReload => _magazine.CanReset && !_reloadTimer.Playing;

        public void Shoot()
        {
            if (!CanShoot)
                throw new InvalidOperationException(nameof(Shoot));

            _magazine.Get();
            _weapon.Shoot();
            _view.VisualizeBullets(_magazine.Bullets);
        }

        public async void Reload()
        {
            if (!CanReload)
                throw new InvalidOperationException(nameof(Reload));

            _view.Reload();
            _reloadTimer.Play();

            await _reloadTimer.End();

            if (!_enabled)
                return;

            _magazine.Reset();
            _view.VisualizeBullets(_magazine.Bullets);
        }

        public void Enable()
        {
            _view.VisualizeBullets(_magazine.Bullets);
            _weapon.Enable();
            _enabled = true;
        }

        public void Disable()
        {
            _weapon.Disable();
            _enabled = false;

            if (_reloadTimer.Playing)
                _reloadTimer.Cancel();
        }
    }
}