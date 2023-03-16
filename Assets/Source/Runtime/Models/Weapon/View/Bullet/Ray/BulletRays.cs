using System;
using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class BulletRays : IBulletRay
    {
        private readonly IPool<IBulletRay> _rays;
        private readonly ITimerFactory _timerFactory;

        public BulletRays(IPool<IBulletRay> pool, ITimerFactory rayTimerFactory)
        {
            _rays = pool.ThrowExceptionIfArgumentNull(nameof(pool));
            _timerFactory = rayTimerFactory.ThrowExceptionIfArgumentNull(nameof(rayTimerFactory));
        }

        public void Cast()
        {
            var ray = _rays.Get();
            Cast(ray, () => ray.Cast());
        }

        public void Cast(Vector3 target)
        {
            var ray = _rays.Get();
            Cast(ray, () => ray.Cast(target));
        }

        private async void Cast(IBulletRay ray, Action action)
        {
            action.Invoke();
            
            var timer = _timerFactory.Create();
            timer.Play();
            await timer.End();

            _rays.Return(ray);
        }
    }
}