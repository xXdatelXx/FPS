using UnityEngine;
using UnityEngine.Events;

namespace FPS.Model
{
    // For test
    [RequireComponent(typeof(Collider))]
    public sealed class Enemy : MonoBehaviour, IHealth
    {
        [SerializeField] private UnityEvent _onDie;
        private IHealth _health;

        private void Awake() => _health = new Health(100);
        public bool Died => _health.Died;

        public void TakeDamage(float damage)
        {
            _health.TakeDamage(damage);

            if (Died)
                _onDie.Invoke();
        }
    }
}