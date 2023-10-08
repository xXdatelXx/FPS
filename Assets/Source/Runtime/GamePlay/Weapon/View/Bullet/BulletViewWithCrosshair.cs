using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class BulletViewWithCrosshair : IBulletView
    {
        private readonly IBulletView _bullet;
        private readonly ICrosshair _crosshair;

        public BulletViewWithCrosshair(IBulletView bullet, ICrosshair crosshair)
        {
            _bullet = bullet.ThrowExceptionIfArgumentNull(nameof(bullet));
            _crosshair = crosshair.ThrowExceptionIfArgumentNull(nameof(crosshair));
        }

        public BulletViewWithCrosshair(ICrosshair crosshair) : this(new NullBulletView(), crosshair)
        { }

        public void Miss() => _bullet.Miss();

        public void Hit(Vector3 target) => _bullet.Hit(target);

        public void Kill()
        {
            _bullet.Kill();
            _crosshair.Hit();
        }

        public void Damage()
        {
            _bullet.Damage();
            _crosshair.Kill();
        }
    }
}