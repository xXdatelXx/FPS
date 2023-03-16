namespace FPS.Tools
{
    public sealed class TimerFactory : ITimerFactory
    {
        private readonly float _time;

        public TimerFactory(float time) =>
            _time = time.ThrowExceptionIfValueSubZero(nameof(time));

        public ITimer Create() => new Timer(_time);
    }
}