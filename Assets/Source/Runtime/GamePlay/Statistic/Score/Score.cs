using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class Score : IScore
    {
        private readonly IScoreView _view;

        public Score(IScoreView view) => 
            _view = view.ThrowExceptionIfArgumentNull(nameof(view));

        public int Value { get; private set; }

        public void Increase(int value)
        {
            Value += value.ThrowExceptionIfValueSubZero(nameof(Score));
            _view.Visualize(Value);
        }
    }
}