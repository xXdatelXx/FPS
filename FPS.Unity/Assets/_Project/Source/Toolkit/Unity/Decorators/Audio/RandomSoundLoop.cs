using Cysharp.Threading.Tasks;
using UnityEngine;

namespace FPS.Toolkit
{
    [RequireComponent(typeof(AudioSource))]
    public sealed class RandomSoundLoop : MonoBehaviour
    {
        [SerializeField] private AudioClip[] _clips;
        [SerializeField] private Range _time;
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            StartLoop().Forget();
        }

        private async UniTaskVoid StartLoop()
        {
            while (true)
            {
                var timer = new AsyncTimer(_time.RandomValue());

                timer.Play();
                await timer.End();

                _audioSource.PlayOneShot(_clips.RandomElement());
            }
        }
    }
}