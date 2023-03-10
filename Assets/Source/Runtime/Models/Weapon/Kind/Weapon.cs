using System;
using FPS.Tools;
using JetBrains.Annotations;

namespace FPS.Model
{
    public sealed class Weapon : IWeapon
    {
        private readonly IBulletFactory _factory;
        [CanBeNull] private readonly IWeaponView _view;

        public Weapon(IBulletFactory factory, IWeaponView view = null)
        {
            _factory = factory.ThrowExceptionIfArgumentNull(nameof(factory));
            _view = view;
        }

        public bool CanShoot { get; private set; }

        public void Shoot()
        {
            if (!CanShoot)
                throw new InvalidOperationException(nameof(Shoot));

            _factory.Create().Fire();
            _view?.Shoot();
        }

        public void Enable() => CanShoot = true;
        public void Disable() => CanShoot = false;
    }
}