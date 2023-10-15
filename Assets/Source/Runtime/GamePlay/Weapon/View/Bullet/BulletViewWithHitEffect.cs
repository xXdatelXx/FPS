using Cysharp.Threading.Tasks;
using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class BulletViewWithHitEffect : IBulletView
    {
        private readonly IBulletView _bullet;
        private readonly IPool<IBulletHitView> _hitsPool;
        private readonly IFactory<ITimer> _hitsLifeTimers;

        public BulletViewWithHitEffect(IBulletView bullet, IPool<IBulletHitView> hitsPool, IFactory<ITimer> hitsLifeTimers)
        {
            _bullet = bullet.ThrowExceptionIfArgumentNull(nameof(bullet));
            _hitsPool = hitsPool.ThrowExceptionIfArgumentNull(nameof(hitsPool));
            _hitsLifeTimers = hitsLifeTimers.ThrowExceptionIfArgumentNull(nameof(hitsLifeTimers));
        }

        public BulletViewWithHitEffect(IPool<IBulletHitView> hitsPool, IFactory<ITimer> hitsLifeTimers) 
            : this(new NullBulletView(), hitsPool, hitsLifeTimers)
        { }

        public void Miss() => _bullet.Miss();

        public void Hit(Vector3 target)
        {
            _bullet.Hit(target);
            CreateHitView(target).Forget();
        }

        private async UniTaskVoid CreateHitView(Vector3 target)
        {
            var hit = _hitsPool.Get();
            hit.Visualize(target);
            
            var timer = _hitsLifeTimers.Create();
            timer.Play();
            await timer.End();

            hit.Hide();
            _hitsPool.Return(hit);
        }

        public void Kill() => _bullet.Kill();

        public void Damage() => _bullet.Damage();
    }
}