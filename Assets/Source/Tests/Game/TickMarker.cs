using FPS.Game.Loop;

namespace Source.Tests.Game
{
    public sealed class TickMarker : IFixedTickable
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