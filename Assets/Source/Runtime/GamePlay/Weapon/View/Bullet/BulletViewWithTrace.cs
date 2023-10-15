using Cysharp.Threading.Tasks;
using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class BulletViewWithTrace : IBulletView
    {
        private readonly IBulletView _bullet;
        private readonly IPool<IBulletTrace> _tracePool;
        private readonly IFactory<ITimer> _traceLifeTimers;
        
        public BulletViewWithTrace(IBulletView bullet, IPool<IBulletTrace> tracePool, IFactory<ITimer> traceLifeTimers)
        {
            _bullet = bullet.ThrowExceptionIfArgumentNull(nameof(bullet));
            _tracePool = tracePool.ThrowExceptionIfArgumentNull(nameof(tracePool));
            _traceLifeTimers = traceLifeTimers.ThrowExceptionIfArgumentNull(nameof(traceLifeTimers));
        }
        
        public BulletViewWithTrace(IPool<IBulletTrace> pool, IFactory<ITimer> timerFactory) 
            : this(new NullBulletView(), pool, timerFactory)
        { }

        public void Miss()
        {
            _bullet.Miss();
            
            var trace = _tracePool.Get();
            trace.Cast();
            Hide(trace).Forget();
        }

        public void Hit(Vector3 target)
        {
            _bullet.Hit(target);
            
            var trace = _tracePool.Get();
            trace.Cast(target);
            Hide(trace).Forget();
        }
        
        private async UniTaskVoid Hide(IBulletTrace trace)
        {
            var timer = _traceLifeTimers.Create();
            timer.Play();
            await timer.End();

            trace.Hide();
            _tracePool.Return(trace);
        }

        public void Kill() => _bullet.Kill();

        public void Damage() => _bullet.Damage();
    }
}