using System;
using Source.Runtime.Model.Timer;
using Source.Runtime.Tools.Extensions;
using Source.Runtime.Tools.Math;

namespace FPS.Model.Weapons.Bullet
{
    public sealed class Magazine : IMagazine
    {
        private readonly ITimer _reloadTimer;
        private IntWithStandard _bulletCount;
        public bool CanShoot => _bulletCount > 0 && !_reloadTimer.Playing;
        public bool CanReload => _bulletCount.StandardEqualsValue;

        public Magazine(ITimer reloadTimer, int bulletCount)
        {
            _reloadTimer = reloadTimer.ThrowExceptionIfArgumentNull(nameof(reloadTimer));
            _bulletCount = new IntWithStandard(bulletCount.ThrowExceptionIfValueSubZero(nameof(bulletCount)));
        }

        public void Get()
        {
            if (!CanShoot)
                throw new InvalidOperationException(nameof(CanShoot));

            _bulletCount--;
        }

        public void Reload()
        {
            if (!CanReload)
                throw new InvalidOperationException(nameof(Reload));
                
            _reloadTimer.Play();
            _bulletCount.Reset();
        }
    }
}