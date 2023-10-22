using UnityEngine;

namespace FPS.Toolkit
{
    public sealed class UnitySound : ISound
    {
        private readonly AudioSource _source;
        private readonly AudioClip _clip;

        public UnitySound(AudioSource source, AudioClip clip)
        {
            _source = source.ThrowExceptionIfArgumentNull(nameof(source));
            _clip = clip.ThrowExceptionIfArgumentNull(nameof(clip));
        }

        public UnitySound(AudioSource source) : this(source, source.clip)
        { }

        public void Play() => 
            _source.PlayOneShot(_clip);
    }
}