using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class CharacterScoreView : ICharacterScoreView
    {
        private readonly IText _text;

        public CharacterScoreView(IText text) =>
            _text = text.ThrowExceptionIfArgumentNull(nameof(text));

        public void Visualize(int kills) => 
            _text.Visualize(kills);
    }
}