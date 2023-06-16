namespace FPS.Tools.GameLoop
{
    public interface IGameTime : IReadOnlyGameTime
    {
        void Enable();
        void Disable();
    }
}