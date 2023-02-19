using Source.Runtime.Models.Game.Loop.Tickables;

namespace Source.Runtime.Models.Game.Loop
{
    public interface IGameLoop
    {
        void Add(ITickable tickable);
        void Add(ILateTickable tickable);
        void Add(IFixedTickable tickable);
        void Start();
    }
}