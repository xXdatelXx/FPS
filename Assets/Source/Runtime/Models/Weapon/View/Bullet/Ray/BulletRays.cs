using System;
using System.Collections.Generic;
using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class BulletRays : IBulletRay
    {
        private readonly IPool<IBulletRay> _pool;
        private readonly IList<IBulletRay> _rays;
        private readonly IFactory<ITimer> _timerFactory;

        public BulletRays(IPool<IBulletRay> pool, IFactory<ITimer> rayTimerFactory)
        {
            _pool = pool.ThrowExceptionIfArgumentNull(nameof(pool));
            _rays = new List<IBulletRay>();
            _timerFactory = rayTimerFactory.ThrowExceptionIfArgumentNull(nameof(rayTimerFactory));
        }

        public void Cast()
        {
            var ray = _pool.Get();
            Cast(ray, () => ray.Cast());
        }

        public void Cast(Vector3 target)
        {
            var ray = _pool.Get();
            Cast(ray, () => ray.Cast(target));
        }

        public void Hide()
        {
            foreach (var ray in _rays)
            {
                _pool.Return(ray);
                _rays.Remove(ray);
                ray.Hide();
            }
        }

        private async void Cast(IBulletRay ray, Action action)
        {
            _rays.Add(ray);
            action.Invoke();

            var timer = _timerFactory.Create();
            timer.Play();
            await timer.End();

            if (!_pool.Contains(ray))
            {
                ray.Hide();
                _pool.Return(ray);
            }
        }
    }
}