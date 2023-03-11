using FPS.Game.Loop;

namespace FPS.Game
{
    public interface IReadOnlyGameLoop
    {
        void Add(ITickable tickable);
        void Add(ILateTickable tickable);
        void Add(IFixedTickable tickable);
    }
}