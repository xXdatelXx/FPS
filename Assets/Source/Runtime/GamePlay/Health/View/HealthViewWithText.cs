using System;
using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class HealthViewWithText : IHealthView
    {
        private readonly IHealthView _healthView;
        private readonly IText _healthText;
        private readonly int _textPrecision;

        public HealthViewWithText(IHealthView view, IText healthText, int textPrecision = 1)
        {
            _healthView = view.ThrowExceptionIfArgumentNull(nameof(view));
            _healthText = healthText.ThrowExceptionIfArgumentNull(nameof(healthText));
            _textPrecision = textPrecision.ThrowExceptionIfValueSubZero(nameof(textPrecision));
        }

        public void Damage(float health)
        {
            _healthView.Damage(health);
            Visualize(health);
        }

        public void Heal(float health)
        {
            _healthView.Heal(health);
            Visualize(health);
        }

        public void Die()
        {
            _healthView.Die();
            Visualize(0);
        }

        private void Visualize(float health) =>
            _healthText.Visualize(Math.Round(health, _textPrecision));
    }
}