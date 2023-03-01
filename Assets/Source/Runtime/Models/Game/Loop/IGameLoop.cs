using FPS.Game.Loop;

namespace FPS.Game
{
    public interface IGameLoop
    {
        void Add(ITickable tickable);
        void Add(ILateTickable tickable);
        void Add(IFixedTickable tickable);
        void Start();
    }
}