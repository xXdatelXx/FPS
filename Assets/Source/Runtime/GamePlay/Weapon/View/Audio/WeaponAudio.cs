using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    [RequireComponent(typeof(AudioSource))]
    public sealed class WeaponAudio : MonoBehaviour, IWeaponAudio
    {
        [SerializeField] private AudioClip[] _shootClips;
        [SerializeField] private AudioClip _reload;
        [SerializeField] private AudioClip _equip;
        [SerializeField] private AudioClip _uneQuip;
        private AudioSource _audioSource;

        private void Awake() =>
            _audioSource = GetComponent<AudioSource>();

        public void Shoot() =>
            _audioSource.PlayOneShot(_shootClips.RandomElement());

        public void Reload() =>
            _audioSource.PlayOneShot(_reload);

        public void Equip() =>
            _audioSource.PlayOneShot(_equip);

        public void UneQuip() =>
            _audioSource.PlayOneShot(_uneQuip);
    }
}