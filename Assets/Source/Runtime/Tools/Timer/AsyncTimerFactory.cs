namespace FPS.Tools
{
    public sealed class AsyncTimerFactory : IFactory<ITimer>
    {
        private readonly float _time;

        public AsyncTimerFactory(float time) =>
            _time = time.ThrowExceptionIfValueSubZero(nameof(time));

        public ITimer Create() => new AsyncTimer(_time);
    }
}