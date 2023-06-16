using UnityEngine;

namespace FPS.Tools
{
    public sealed class UnityAnimation : IAnimation
    {
        private readonly Animator _animator;
        private readonly string _animation;

        public UnityAnimation(Animator animator, string animation)
        {
            _animator = animator.ThrowExceptionIfArgumentNull(nameof(animator));
            _animation = animation.ThrowExceptionIfArgumentNull(nameof(animation));
        }

        public void Play() => _animator.Play(_animation);
    }
}