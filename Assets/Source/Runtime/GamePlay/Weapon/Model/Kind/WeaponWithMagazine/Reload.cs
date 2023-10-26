using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class Reload : ITimerWithCanceling
    {
        private readonly ITimerWithCanceling _timer;
        private readonly IWeaponView _view;

        public Reload(ITimer timer, IWeaponView view) : this(new TimerWithCanceling(timer), view)
        { }

        public Reload(ITimerWithCanceling timer, IWeaponView view)
        {
            _timer = timer.ThrowExceptionIfArgumentNull(nameof(timer));
            _view = view.ThrowExceptionIfArgumentNull(nameof(view));
        }

        public bool Playing => _timer.Playing;
        public bool Canceled => _timer.Canceled;

        public void Play()
        {
            _timer.Play();
            _view.Reload();
        }

        public void Stop() => _timer.Stop();
        public void Cancel() => _timer.Cancel();
    }
}