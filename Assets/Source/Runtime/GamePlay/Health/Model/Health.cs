using System;
using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class Health : IHealthWithHeal
    {
        private readonly float _maxPoints;
        private readonly IHealthView _view;

        public Health(float value) : this(value, new NullHealthView())
        {
        }

        public Health(float value, IHealthView view)
        {
            Points = value.ThrowExceptionIfValueSubOrEqualZero(nameof(Health));
            _maxPoints = Points;
            _view = view.ThrowExceptionIfArgumentNull(nameof(view));
            _view.Visualize(value);
        }

        public float Points { get; private set; }
        public bool Died => Points <= 0;
        public bool CanHeal => !Died && _maxPoints > Points;

        public void TakeDamage(float damage)
        {
            if (Died)
                throw new InvalidOperationException(nameof(TakeDamage));

            damage.ThrowExceptionIfValueSubZero(nameof(damage));

            Points = Math.Max(Points - damage, 0);
            _view.Visualize(Points);

            if (Died)
                _view.Die();
        }

        public void Heal(float heal)
        {
            if (!CanHeal)
                throw new InvalidOperationException(nameof(Heal));

            heal.ThrowExceptionIfValueSubOrEqualZero(nameof(heal));

            Points = Math.Min(Points + heal, _maxPoints);
            _view.Visualize(Points);
        }
    }
}