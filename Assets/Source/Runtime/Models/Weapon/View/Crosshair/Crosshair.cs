using FPS.Tools;

namespace FPS.Model
{
    public sealed class Crosshair : ICrosshair
    {
        private readonly ICrosshairAnimator _animator;

        public Crosshair(ICrosshairAnimator animator) =>
            _animator = animator.ThrowExceptionIfArgumentNull(nameof(animator));

        public void Hit() =>
            _animator.PlayHit();

        public void Kill() =>
            _animator.PlayKill();
    }
}