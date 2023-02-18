using System;
using FPS.Model.Weapons.Bullet;
using Source.Runtime.Model.Timer;
using Source.Runtime.Models.Weapon.Views;
using Source.Runtime.Tools.Extensions;

namespace FPS.Model.Weapons
{
    public sealed class WeaponWithMagazine : IWeaponWithMagazine
    {
        private readonly IWeapon _weapon;
        private readonly IMagazine _magazine;
        private readonly ITimer _reloadTimer;
        private readonly IWeaponView _view;
        private bool _enabled;
        public bool CanShoot => _weapon.CanShoot && _magazine.CanGet;
        public bool CanReload => _magazine.CanReset && !_reloadTimer.Playing;

        public WeaponWithMagazine(IWeapon weapon, IMagazine magazine, ITimer reloadTimer, IWeaponView view)
        {
            _weapon = weapon.ThrowExceptionIfArgumentNull(nameof(weapon));
            _magazine = magazine.ThrowExceptionIfArgumentNull(nameof(magazine));
            _reloadTimer = reloadTimer.ThrowExceptionIfArgumentNull(nameof(reloadTimer));
            _view = view.ThrowExceptionIfArgumentNull(nameof(view));
        }

        public void Shoot()
        {
            if (!CanShoot)
                throw new InvalidOperationException(nameof(Shoot));

            _magazine.Get();
            _weapon.Shoot();
            _view.VisualizeBullets(_magazine.Bullets.Value);
        }

        public async void Reload()
        {
            if (!CanReload)
                throw new InvalidOperationException(nameof(Reload));

            _view.OnReload();
            _reloadTimer.Play();

            await _reloadTimer.End();

            if (!_enabled)
                return;

            _magazine.Reset();
            _view.VisualizeBullets(_magazine.Bullets.Value);
        }

        public void Enable()
        {
            _view.VisualizeBullets(_magazine.Bullets.Value);
            _weapon.Enable();
            _enabled = true;
        }

        public void Disable()
        {
            _weapon.Disable();
            _reloadTimer.Cancel();
            _enabled = false;
        }
    }
}