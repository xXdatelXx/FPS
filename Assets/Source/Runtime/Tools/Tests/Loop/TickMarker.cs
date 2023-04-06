using FPS.Tools.GameLoop;

namespace FPS.Tools.Tests
{
    internal sealed class TickMarker : IFixedGameLoopObject
    {
        public bool WasTick { get; private set; }
        public float DeltaTime { get; private set; }

        public void FixedTick(float deltaTime)
        {
            WasTick = true;
            DeltaTime = deltaTime;
        }
    }
}