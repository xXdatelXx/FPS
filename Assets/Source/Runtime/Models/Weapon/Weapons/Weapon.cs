using System;
using FPS.Model.Weapons.Bullet;
using Source.Runtime.Models.Weapon.Views;
using Source.Runtime.Tools.Extensions;

namespace FPS.Model.Weapons
{
    public sealed class Weapon : IWeapon
    {
        private readonly IMagazine _magazine;
        private readonly IBulletFactory _factory;
        private readonly IWeaponView _view;
        public bool CanShoot => _magazine.CanShoot;
        public bool CanReload => _magazine.CanReload;

        public Weapon(IMagazine magazine, IBulletFactory factory, IWeaponView view)
        {
            _magazine = magazine.ThrowExceptionIfArgumentNull(nameof(magazine));
            _factory = factory.ThrowExceptionIfArgumentNull(nameof(factory));
            _view = view.ThrowExceptionIfArgumentNull(nameof(view));
        }

        public void Shoot()
        {
            if (!CanShoot)
                throw new InvalidOperationException(nameof(CanShoot));

            _factory.Create().Fire();
            _magazine.Get();
            _view.Shoot();
        }

        public void Reload()
        {
            _magazine.Reload();
            _view.Reload();
        }
    }
}