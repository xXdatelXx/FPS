namespace Source.Runtime.Views.GameObject
{
    public interface IGameObject
    {
        bool Active { get; }
        void Destroy();
        void Enable();
        void Disable();
    }
}