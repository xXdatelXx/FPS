using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class LoseView : ILoseView
    {
        private readonly IAnimation _animation;

        public LoseView(IAnimation animation) => 
            _animation = animation.ThrowExceptionIfArgumentNull(nameof(animation));

        public void Visualize() => 
            _animation.Play();
    }
}