using FPS.GamePlay;
using FPS.Toolkit;
using UnityEngine;

namespace FPS.Factories
{
    public sealed class CharacterHealthViewFactory : MonoBehaviour, IFactory<IHealthView>
    {
        [Header("Animation")]
        [SerializeField] private Animator _animator;
        [SerializeField] private string _damageAnimation;
        [Header("Audio")]
        [SerializeField] private AudioClip _damageSound;
        [SerializeField] private AudioClip _dieSound;
        [SerializeField] private AudioSource _audioSource;
        [Header("Other")]
        [SerializeField] private ProText _healthText;
        [SerializeField] private LoseView _lose;
        
        public IHealthView Create()
        {
            var damageAnimation = new UnityAnimation(_animator, _damageAnimation);
            var damageSound = new UnitySound(_audioSource, _damageSound);
            var dieSound = new UnitySound(_audioSource, _dieSound);

            var characterView = new CharacterHealthView(damageAnimation, _lose);
            var viewWithText = new HealthViewWithText(characterView, _healthText);
            var viewWithSounds = new HealthViewWithSounds(viewWithText, damageSound, dieSound);

            return viewWithSounds;
        }
    }
}