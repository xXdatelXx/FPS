namespace FPS.Tools.GameLoop
{
    public interface IReadOnlyGameLoop
    {
        void Add(ITickable tickable);
        void Add(ILateTickable tickable);
        void Add(IFixedTickable tickable);
    }
}