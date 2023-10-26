using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class AttackView : IAttackView
    {
        private readonly IAnimation _animation;

        public AttackView(IAnimation animation) =>
            _animation = animation.ThrowExceptionIfArgumentNull(nameof(animation));

        public void Attack() => _animation.Play();
    }
}