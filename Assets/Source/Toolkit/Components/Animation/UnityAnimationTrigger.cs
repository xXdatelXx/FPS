using UnityEngine;

namespace FPS.Toolkit
{
    public sealed class UnityAnimationTrigger : IAnimation
    {
        private readonly Animator _animator;
        private readonly string _trigger;

        public UnityAnimationTrigger(Animator animator, string trigger)
        {
            _animator = animator.ThrowExceptionIfArgumentNull(nameof(animator));
            _trigger = trigger.ThrowExceptionIfArgumentNull(nameof(trigger));
        }

        public void Play() => _animator.SetTrigger(_trigger);
    }
}