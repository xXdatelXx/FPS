using FPS.Toolkit;

namespace FPS.Model
{
    public sealed class CharacterHealthView : IHealthView
    {
        private readonly IGameObject _character;
        private readonly IText _healthText;

        public CharacterHealthView(IGameObject character, IText healthText)
        {
            _healthText = healthText.ThrowExceptionIfArgumentNull(nameof(healthText));
            _character = character.ThrowExceptionIfArgumentNull(nameof(character));
        }

        public void Visualize(float health) =>
            _healthText.Visualize(health);

        public void Die() =>
            _character.Destroy();
    }
}