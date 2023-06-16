using FPS.Tools.GameLoop;

namespace FPS.Tools.Tests
{
    internal sealed class TickMarker : IGameLoopObject
    {
        public bool WasTick { get; private set; }
        public float DeltaTime { get; private set; }

        public void Tick(float deltaTime)
        {
            WasTick = true;
            DeltaTime = deltaTime;
        }
    }
}