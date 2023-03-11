using System;
using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class BulletRays : IBulletRays
    {
        private readonly IPool<IBulletRay> _rays;

        public BulletRays(IPool<IBulletRay> rays) =>
            _rays = rays.ThrowExceptionIfArgumentNull(nameof(rays));

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
            await ray.End();
            _rays.Return(ray);
        }
    }
}