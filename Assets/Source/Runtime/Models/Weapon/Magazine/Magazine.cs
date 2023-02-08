using System;
using Source.Runtime.Model.Timer;
using Source.Runtime.Tools.Extensions;
using Source.Runtime.Tools.Math;

namespace FPS.Model.Weapons.Bullet
{
    public sealed class Magazine : IMagazine
    {
        private readonly ITimer _reloadTimer;
        public IntWithStandard Bullets { get; private set; }
        public bool CanShoot => Bullets > 0 && !_reloadTimer.Playing;
        public bool CanReload => Bullets.StandardEqualsValue;

        public Magazine(ITimer reloadTimer, int bulletCount)
        {
            _reloadTimer = reloadTimer.ThrowExceptionIfArgumentNull(nameof(reloadTimer));
            Bullets = new IntWithStandard(bulletCount.ThrowExceptionIfValueSubZero(nameof(bulletCount)));
        }

        public void Get()
        {
            if (!CanShoot)
                throw new InvalidOperationException(nameof(CanShoot));

            Bullets--;
        }

        public void Reload()
        {
            if (!CanReload)
                throw new InvalidOperationException(nameof(Reload));
                
            _reloadTimer.Play();
            Bullets.Reset();
        }
    }
}