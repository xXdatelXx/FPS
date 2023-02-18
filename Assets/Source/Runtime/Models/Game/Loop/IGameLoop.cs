using Source.Runtime.TickSystem;

namespace FPS.Model
{
    public interface IGameLoop
    {
        void Add(ITickable tickable);
        void Add(ILateTickable tickable);
        void Add(IFixedTickable tickable);
        void Start();
    }
}