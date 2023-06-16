using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class RandomBulletRay : IBulletRay
    {
        private readonly IRandom<bool> _random;
        private readonly IBulletRay _ray;

        public RandomBulletRay(IBulletRay ray, IRandom<bool> random)
        {
            _ray = ray.ThrowExceptionIfArgumentNull(nameof(ray));
            _random = random.ThrowExceptionIfArgumentNull(nameof(random));
        }

        public void Cast()
        {
            if (_random.Next())
                _ray.Cast();
        }

        public void Cast(Vector3 target)
        {
            if (_random.Next())
                _ray.Cast(target);
        }

        public void Hide() => _ray.Hide();
    }
}