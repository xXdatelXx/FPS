using System;
using Source.Runtime.Models.Weapons.Bullet.Factory;
using Source.Runtime.Models.Weapons.Kind.Interfaces;
using Source.Runtime.Models.Weapons.Views;
using Source.Runtime.Tools.Extensions;

namespace Source.Runtime.Models.Weapons.Kind
{
    public sealed class Weapon : IWeapon
    {
        private readonly IBulletFactory _factory;
        private readonly IWeaponView _view;

        public Weapon(IBulletFactory factory, IWeaponView view)
        {
            _factory = factory.ThrowExceptionIfArgumentNull(nameof(factory));
            _view = view.ThrowExceptionIfArgumentNull(nameof(view));
        }

        public bool CanShoot { get; private set; }

        public void Shoot()
        {
            if (!CanShoot)
                throw new InvalidOperationException(nameof(Shoot));

            _factory.Create().Fire();
            _view.Shoot();
        }

        public void Enable() => CanShoot = true;

        public void Disable() => CanShoot = false;
    }
}