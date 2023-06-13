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
        
        public void Play() => _timer.Play();
        public void Stop() => _timer.Stop();

        public void Cancel()
        {
            if (Canceled)
                throw new InvalidOperationException(nameof(Cancel));

            Canceled = true;
        }
    }
}