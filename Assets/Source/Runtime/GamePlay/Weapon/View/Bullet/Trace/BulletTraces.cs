using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class BulletTraces : IBulletTrace
    {
        private readonly IPool<IBulletTrace> _pool;
        private readonly List<IBulletTrace> _traces;
        private readonly IFactory<ITimer> _timerFactory;

        public BulletTraces(IPool<IBulletTrace> pool, IFactory<ITimer> rayTimerFactory)
        {
            _pool = pool.ThrowExceptionIfArgumentNull(nameof(pool));
            _timerFactory = rayTimerFactory.ThrowExceptionIfArgumentNull(nameof(rayTimerFactory));
            _traces = new();
        }

        public void Cast()
        {
            var trace = _pool.Get();
            trace.Cast();
            Hide(trace).Forget();
        }

        public void Cast(Vector3 target)
        {
            var trace = _pool.Get();
            trace.Cast(target);
            Hide(trace).Forget();
        }

        private async UniTaskVoid Hide(IBulletTrace trace)
        {
            _traces.Add(trace);

            var timer = _timerFactory.Create();
            timer.Play();
            await timer.End();

            trace.Hide();
            _pool.Return(trace);
        }
        
        public void Hide()
        {
            foreach (var ray in _traces)
            {
                _pool.Return(ray);
                _traces.Remove(ray);
                ray.Hide();
            }
        }
    }
}