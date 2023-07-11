using UnityEngine;

namespace FPS.GamePlay
{
    [RequireComponent(typeof(Animator))]
    public sealed class EnemyHealthView : MonoBehaviour, IHealthView
    {
        [SerializeField] private string _dieAnimation;
        [SerializeField, Range(0, 10)] private float _dieTime;
        private Animator _animator;

        private void Awake() => _animator = GetComponent<Animator>();

        public void Visualize(float health)
        {
        }

        public void Die()
        {
            _animator.Play(_dieAnimation);
            Destroy(gameObject, _dieTime);
        }
    }
}