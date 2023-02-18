using System;
using FPS.Model.Weapons.Bullet;
using Source.Runtime.Models.Weapon.Views;
using Source.Runtime.Tools.Extensions;

namespace FPS.Model.Weapons
{
    public sealed class Weapon : IWeapon
    {
        private readonly IBulletFactory _factory;
        private readonly IWeaponView _view;
        public bool CanShoot { get; private set; }

        public Weapon(IBulletFactory factory, IWeaponView view)
        {
            _factory = factory.ThrowExceptionIfArgumentNull(nameof(factory));
            _view = view.ThrowExceptionIfArgumentNull(nameof(view));
        }

        public void Shoot()
        {
            if (!CanShoot)
                throw new InvalidOperationException(nameof(Shoot));

            _factory.Create().Fire();
            _view.OnShoot();
        }

        public void Enable() => CanShoot = true;
        public void Disable() => CanShoot = false;
    }
}