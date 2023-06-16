namespace FPS.Toolkit.GameLoop
{
    public interface IGameTime : IReadOnlyGameTime
    {
        void Enable();
        void Disable();
    }
}