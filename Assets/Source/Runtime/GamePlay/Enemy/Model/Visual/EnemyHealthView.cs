using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    [RequireComponent(typeof(Animator))]
    public sealed class EnemyHealthView : MonoBehaviour, IHealthView
    {
        [SerializeField] private string _dieAnimation;
        [SerializeField, Range(0, 10)] private float _dieTime;
        private Animator _animator;
        private IReword _reword;

        public void Construct(IReword reword)
        {
            _animator = GetComponent<Animator>();
            _reword = reword.ThrowExceptionIfArgumentNull(nameof(reword));
        }

        public void Damage(float health)
        {
        }

        public void Heal(float health)
        {
        }

        public void Die()
        {
            _animator.Play(_dieAnimation);
            _reword.Receive();
            Destroy(gameObject, _dieTime);
        }
    }
}