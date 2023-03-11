using UnityEngine;

namespace FPS.Tools
{
    public sealed class UnityAnimation : IAnimation
    {
        private readonly Animation _animation;

        public UnityAnimation(Animation animation) => 
            _animation = animation.ThrowExceptionIfArgumentNull(nameof(animation));

        public void Play() => _animation.Play();
    }
}