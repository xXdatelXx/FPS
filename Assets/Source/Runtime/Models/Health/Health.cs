using System;
using Source.Runtime.Models.HealthSystem.Policy;
using Source.Runtime.Models.HealthSystem.Views;
using Source.Runtime.Tools.Extensions;

namespace Source.Runtime.Models.HealthSystem
{
    public sealed class Health : IHealth
    {
        private readonly IDeathPolicy _deathPolicy;
        private readonly IHealthView _view;
        private float _point;

        public Health(float value, IDeathPolicy deathPolicy) : this(value, deathPolicy, new DummyHealthView())
        { }

        public Health(float value, IHealthView view) : this(value, new DeathPolicy(), view)
        { }

        public Health(float value, IDeathPolicy deathPolicy, IHealthView view)
        {
            _point = value.ThrowExceptionIfValueSubOrEqualZero(nameof(Health));
            _deathPolicy = deathPolicy.ThrowExceptionIfArgumentNull(nameof(deathPolicy));
            _view = view.ThrowExceptionIfArgumentNull(nameof(view));
            _view.Visualize(value);
        }

        public bool Died => _deathPolicy.Died(_point);

        public void TakeDamage(float damage)
        {
            if (Died)
                throw new InvalidOperationException(nameof(TakeDamage));

            _point = Math.Min(_point - damage, 0);
            _view.Visualize(_point);

            if (Died)
                _view.Die();
        }
    }
}