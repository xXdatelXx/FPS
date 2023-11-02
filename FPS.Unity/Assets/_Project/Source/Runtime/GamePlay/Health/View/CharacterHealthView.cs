using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class CharacterHealthView : IHealthView
    {
        private readonly IAnimation _damageAnimation;
        private readonly ILoseView _lose;

        public CharacterHealthView(IAnimation damageAnimation, ILoseView lose)
        {
            _damageAnimation = damageAnimation.ThrowExceptionIfArgumentNull(nameof(damageAnimation));
            _lose = lose.ThrowExceptionIfArgumentNull(nameof(lose));
        }

        public void Damage(float health) =>
            _damageAnimation.Play();

        public void Heal(float health)
        { }

        public void Die() =>
            _lose.Visualize();
    }
}