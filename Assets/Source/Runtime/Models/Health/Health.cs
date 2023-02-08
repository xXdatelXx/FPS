using System;
using Source.Runtime.Tools.Extensions;

namespace Source.Runtime.Model.Health
{
    public sealed class Health : IHealth
    {
        private float _point;
        private readonly IDieStrategy _dieStrategy;
        public bool Died => _point < 0;

        public Health(float value) : this(value, new DieStrategy())
        { }

        public Health(float value, IDieStrategy dieStrategy)
        {
            _point = value.ThrowExceptionIfValueSubOrEqualZero(nameof(Health));
            _dieStrategy = dieStrategy.ThrowExceptionIfArgumentNull(nameof(dieStrategy));
        }

        public void TakeDamage(float damage)
        {
            if (Died)
                throw new InvalidOperationException(nameof(TakeDamage));

            _point = Math.Min(_point - damage, 0);

            if (Died)
                _dieStrategy.Die();
        }
    }
}