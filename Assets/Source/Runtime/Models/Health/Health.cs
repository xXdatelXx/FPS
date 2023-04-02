using System;
using FPS.Tools;

namespace FPS.Model
{
    public sealed class Health : IHealth
    {
        private readonly IHealthView _view;
        private float _point;

        public Health(float value) : this(value, new NullHealthView())
        { }

        public Health(float value, IHealthView view)
        {
            _point = value.ThrowExceptionIfValueSubOrEqualZero(nameof(Health));
            _view = view.ThrowExceptionIfArgumentNull(nameof(view));
            _view.Visualize(value);
        }

        public bool Died => _point == 0;

        public void TakeDamage(float damage)
        {
            if (Died)
                throw new InvalidOperationException(nameof(TakeDamage));

            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            _point = Math.Max(_point - damage, 0);
            _view.Visualize(_point);

            if (Died)
                _view.Die();
        }
    }
}