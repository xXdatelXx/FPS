using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class CrosshairAnimator : ICrosshairAnimator
    {
        private readonly IAnimation _hit;
        private readonly IAnimation _kill;

        public CrosshairAnimator(Animator animator, string hit, string kill)
            : this(new UnityAnimationTrigger(animator, hit), new UnityAnimationTrigger(animator, kill))
        { }

        public CrosshairAnimator(IAnimation hit, IAnimation kill)
        {
            _hit = hit.ThrowExceptionIfArgumentNull(nameof(hit));
            _kill = kill.ThrowExceptionIfArgumentNull(nameof(kill));
        }

        public void PlayHit() =>
            _hit.Play();

        public void PlayKill() =>
            _kill.Play();
    }
}