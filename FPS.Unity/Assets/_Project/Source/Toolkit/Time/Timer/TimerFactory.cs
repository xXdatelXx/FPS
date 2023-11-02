using FPS.Toolkit.GameLoop;

namespace FPS.Toolkit
{
    public sealed class TimerFactory : IFactory<ITimer>
    {
        private readonly float _time;
        private readonly IGameLoopObjectsGroup _timers;

        public TimerFactory(float time, IGameLoopObjectsGroup timers)
        {
            _time = time.ThrowExceptionIfValueSubZero(nameof(time));
            _timers = timers;
        }

        public ITimer Create()
        {
            var timer = new Timer(_time);
            _timers.Add(timer);

            return timer;
        }
    }
}