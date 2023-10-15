using System;
using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class Weapon : IWeapon
    {
        private readonly IBulletFactory _bullets;

        public Weapon(IBulletFactory factory) => 
            _bullets = factory.ThrowExceptionIfArgumentNull(nameof(factory));

        public bool CanShoot { get; private set; }

        public void Shoot()
        {
            if (!CanShoot)
                throw new InvalidOperationException(nameof(Shoot));

            _bullets.Create().Fire();
        }

        public void Enable() => CanShoot = true;
        public void Disable() => CanShoot = false;
    }
}