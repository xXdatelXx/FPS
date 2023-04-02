namespace FPS.Tools
{
    public interface IGameObject
    {
        bool Active { get; }
        void Destroy();
        void Enable();
        void Disable();
    }
}