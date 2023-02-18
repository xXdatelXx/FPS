namespace Source.Runtime.Models.GameObjects
{
    public interface IGameObject
    {
        bool Active { get; }
        void Destroy();
        void Enable();
        void Disable();
    }
}