using UnityEngine;

namespace FPS.GamePlay
{
    [RequireComponent(typeof(Animator))]
    public sealed class EnemyHealthView : MonoBehaviour, IHealthView
    {
        [Header("Animation")]
        [SerializeField] private string _dieAnimation;
        [SerializeField, Range(0, 10)] private float _dieTime;
        private Animator _animator;
        [Header("Sound")]
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _damageSound;
        [SerializeField] private AudioClip _dieSound;

        private void Awake() =>
            _animator = GetComponent<Animator>();

        public void Damage(float health) =>
            _audioSource.PlayOneShot(_damageSound);

        public void Heal(float health)
        { }

        public void Die()
        {
            _animator.Play(_dieAnimation);
            _audioSource.PlayOneShot(_dieSound);
            Destroy(gameObject, _dieTime);
        }
    }
}