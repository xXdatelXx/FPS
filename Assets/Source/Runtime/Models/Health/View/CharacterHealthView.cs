using FPS.Tools;

namespace FPS.Model
{
    public sealed class CharacterHealthView : IHealthView
    {
        private readonly IGameObject _character;
        private readonly ITextView _healthText;

        public CharacterHealthView(IGameObject character, ITextView healthText)
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