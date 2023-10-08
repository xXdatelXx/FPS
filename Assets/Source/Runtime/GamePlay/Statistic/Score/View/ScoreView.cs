using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class ScoreView : IScoreView
    {
        private readonly IText _text;

        public ScoreView(IText text) =>
            _text = text.ThrowExceptionIfArgumentNull(nameof(text));

        public void Visualize(int value) => 
            _text.Visualize(value);
    }
}