using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class WeaponDelay : IWeaponDelay
    {
        private readonly ITimerWithCanceling _timer;

        public WeaponDelay(ITimerWithCanceling timer) =>
            _timer = timer.ThrowExceptionIfArgumentNull(nameof(timer));

        public bool Playing => _timer.Playing;
        public bool Canceled => _timer.Canceled;

        public void Play() => _timer.Play();
        public void Stop() => _timer.Stop();
        public void Cancel() => _timer.Cancel();
    }
}