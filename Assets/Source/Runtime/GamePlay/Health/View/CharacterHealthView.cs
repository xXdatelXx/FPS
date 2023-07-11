using System;
using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class CharacterHealthView : IHealthView
    {
        private readonly IGameObject _character;
        private readonly IText _healthText;
        private readonly int _precision;

        public CharacterHealthView(IGameObject character, IText healthText, int precision = 1)
        {
            _healthText = healthText.ThrowExceptionIfArgumentNull(nameof(healthText));
            _character = character.ThrowExceptionIfArgumentNull(nameof(character));
            _precision = precision.ThrowExceptionIfValueSubZero(nameof(precision));
        }

        public void Visualize(float health) =>
            _healthText.Visualize(Math.Round(health, _precision));

        public void Die() =>
            _character.Destroy();
    }
}