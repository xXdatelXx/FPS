using System;
using FPS.Model.Weapons.Bullet;
using Source.Runtime.Model.Timer;
using Source.Runtime.Tools.Extensions;
using UnityEngine;

namespace FPS.Model.Weapons
{
    public sealed class Weapon : IWeapon
    {
        private readonly IMagazine _magazine;
        private readonly ITimer _delay;
        private readonly IBulletFactory _factory;
        public bool CanShoot => _magazine.CanShoot && !_delay.Playing;
        public bool CanReload => _magazine.CanReload;

        public Weapon(IMagazine magazine, ITimer delay, IBulletFactory factory)
        {
            _magazine = magazine.ThrowExceptionIfArgumentNull(nameof(magazine));
            _delay = delay.ThrowExceptionIfArgumentNull(nameof(delay));
            _factory = factory.ThrowExceptionIfArgumentNull(nameof(factory));
        }

        public void Shoot(Vector3 direction)
        {
            if (!CanShoot)
                throw new InvalidOperationException(nameof(CanShoot));
            
            _factory.Create().Fire(direction);
            _magazine.Get();
            
            Delay();
        }

        public void Reload() =>
            _magazine.Reload();

        private async void Delay()
        {
            _delay.Play();
            await _delay.End();
        }
    }
}