using System;
using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    [RequireComponent(typeof(Collider))]
    [DisallowMultipleComponent]
    public sealed class CharacterOrgan : MonoBehaviour, ICharacterOrgan
    {
        private IHealth _health;
        private float _multiplier;

        public void Construct(IHealth health, float multiplier)
        {
            _health = health.ThrowExceptionIfArgumentNull(nameof(health));
            _multiplier = multiplier.ThrowExceptionIfValueSubZero(nameof(multiplier));
        }

        public bool Died => _health.Died;

        public void TakeDamage(float damage)
        {
            if (Died)
                throw new InvalidOperationException(nameof(TakeDamage));

            damage.ThrowExceptionIfValueSubZero(nameof(damage));

            damage *= _multiplier;
            _health.TakeDamage(damage);
        }
    }
}