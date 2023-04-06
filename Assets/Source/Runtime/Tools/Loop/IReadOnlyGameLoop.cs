namespace FPS.Tools.GameLoop
{
    public interface IReadOnlyGameLoop
    {
        void Add(IGameLoopObject obj);
        void Add(ILateGameLoopObject obj);
        void Add(IFixedGameLoopObject obj);
    }
}