using FPS.Tools.GameLoop;

namespace FPS.Tools
{
    public sealed class TimerFactory : IFactory<ITimer>
    {
        private IGameLoopObjectsGroup _timers;
        private readonly float _time;

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