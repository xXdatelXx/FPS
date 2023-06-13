namespace FPS.Tools.GameLoop
{
    public sealed class GameLoop : IGameLoop
    {
        private readonly IGameLoopObjects _objects;
        private readonly IReadOnlyGameTime _time;

        public GameLoop(IReadOnlyGameTime time, params IGameLoopObject[] loopObject)
            : this(new GameLoopObjects(loopObject), time)
        {
        }

        public GameLoop(IGameLoopObjects objects, IReadOnlyGameTime time)
        {
            _objects = objects.ThrowExceptionIfArgumentNull(nameof(objects));
            _time = time.ThrowExceptionIfArgumentNull(nameof(time));
        }

        public async void Start()
        {
            while (true)
            {
                if (_time.Active)
                    _objects.Tick(_time.FrameDelta);

                await _time.NextFrame();
            }
        }
    }
}