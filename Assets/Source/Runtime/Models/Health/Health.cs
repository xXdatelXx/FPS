using System;
using Source.Runtime.Tools.Extensions;

namespace Source.Runtime.Model.Health
{
    public sealed class Health : IHealth
    {
        private float _value;
        private readonly IDieStrategy _dieStrategy;
        public bool Died => _value < 0;

        public Health(float value) : this(value, new DieStrategy())
        { }

        public Health(float value, IDieStrategy dieStrategy)
        {
            _value = value.ThrowExceptionIfValueSubOrEqualZero(nameof(Health));
            _dieStrategy = dieStrategy.ThrowExceptionIfArgumentNull(nameof(dieStrategy));
        }

        public void TakeDamage(float damage)
        {
            if (Died)
                throw new InvalidOperationException(nameof(TakeDamage));

            _value = Math.Min(_value - damage, 0);

            if (Died)
                _dieStrategy.Die();
        }
    }
}