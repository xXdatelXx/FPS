using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class BulletViewWithTrace : IBulletView
    {
        private readonly IBulletView _bullet;
        private readonly IBulletTrace _traces;

        public BulletViewWithTrace(IBulletView bullet, IBulletTrace traces)
        {
            _bullet = bullet.ThrowExceptionIfArgumentNull(nameof(bullet));
            _traces = traces.ThrowExceptionIfArgumentNull(nameof(traces));
        }

        public BulletViewWithTrace(IBulletTrace traces) : this(new NullBulletView(), traces)
        {
        }

        public void Miss()
        {
            _bullet.Miss();
            _traces.Cast();   
        }

        public void Hit(Vector3 target)
        {
            _traces.Cast(target);
            _bullet.Miss();
        }

        public void Kill() => _bullet.Kill();

        public void Damage() => _bullet.Damage();
    }
}