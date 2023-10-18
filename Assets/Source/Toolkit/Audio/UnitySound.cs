using UnityEngine;

namespace FPS.Toolkit
{
    public sealed class UnitySound : ISound
    {
        private readonly AudioSource _source;

        public UnitySound(AudioSource source) => 
            _source = source.ThrowExceptionIfArgumentNull(nameof(source));

        public void Play() => 
            _source.Play();
    }
}