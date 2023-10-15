using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class ScoreViewWithAnimation : IScoreView
    {
        private readonly IScoreView _view;
        private readonly IAnimation _animation;

        public ScoreViewWithAnimation(IScoreView view, IAnimation animation)
        {
            _view = view.ThrowExceptionIfArgumentNull(nameof(view));
            _animation = animation.ThrowExceptionIfArgumentNull(nameof(animation));
        }

        public void Visualize(int value)
        {
            _animation.Play();
            _view.Visualize(value);
        }
    }
}