using System;
using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class CharacterHealthView : IHealthView
    {
        private readonly IGameObject _character;
        private readonly IText _healthText;
        private readonly IAnimation _damageAnimation;
        private readonly ILoseView _lose;
        private readonly int _precision;

        public CharacterHealthView(IGameObject character, IText healthText, IAnimation damageAnimation, ILoseView lose, int precision = 1)
        {
            _character = character.ThrowExceptionIfArgumentNull(nameof(character));
            _healthText = healthText.ThrowExceptionIfArgumentNull(nameof(healthText));
            _damageAnimation = damageAnimation.ThrowExceptionIfArgumentNull(nameof(damageAnimation));
            _lose = lose.ThrowExceptionIfArgumentNull(nameof(lose));
            _precision = precision.ThrowExceptionIfValueSubZero(nameof(precision));
        }

        public void Damage(float health)
        {
            _damageAnimation.Play();
            Visualize(health);
        }

        public void Heal(float health) =>
            Visualize(health);

        private void Visualize(float health) =>
            _healthText.Visualize(Math.Round(health, _precision));

        public void Die()
        {
            _character.Destroy();
            _lose.Visualize();
        }
    }
}