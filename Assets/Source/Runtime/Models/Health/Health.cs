using System;
using FPS.Tools;
using JetBrains.Annotations;

namespace FPS.Model
{
    public sealed class Health : IHealth
    {
        private readonly IDeathPolicy _deathPolicy;
        [CanBeNull] private readonly IHealthView _view;
        private float _point;

        public Health(float value) : this(value, new DeathPolicy())
        { }

        public Health(float value, IDeathPolicy deathPolicy) : this(value, deathPolicy, null)
        { }

        public Health(float value, IHealthView view) : this(value, new DeathPolicy(), view)
        { }

        public Health(float value, IDeathPolicy deathPolicy, IHealthView view = null)
        {
            _point = value.ThrowExceptionIfValueSubOrEqualZero(nameof(Health));
            _deathPolicy = deathPolicy.ThrowExceptionIfArgumentNull(nameof(deathPolicy));
            _view = view;
            _view?.Visualize(value);
        }

        public bool Died => _deathPolicy.Died(_point);

        public void TakeDamage(float damage)
        {
            if (Died)
                throw new InvalidOperationException(nameof(TakeDamage));
            
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            _point = Math.Max(_point - damage, 0);
            _view?.Visualize(_point);

            if (Died)
                _view?.Die();
        }
    }
}