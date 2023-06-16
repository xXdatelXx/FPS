using System;

namespace FPS.Tools
{
    public sealed class TimerWithCanceling : ITimerWithCanceling
    {
        private readonly ITimer _timer;

        public TimerWithCanceling(ITimer timer) =>
            _timer = timer.ThrowExceptionIfArgumentNull(nameof(timer));

        public bool Playing => _timer.Playing;
        public bool Canceled { get; private set; }

        public void Play()
        {
            Canceled = false;
            _timer.Play();
        }

        public void Stop()
        {
            if (Canceled)
                throw new InvalidOperationException(nameof(Canceled));

            _timer.Stop();
        }

        public void Cancel()
        {
            if (Canceled)
                throw new InvalidOperationException(nameof(Cancel));

            Canceled = true;
        }
    }
}