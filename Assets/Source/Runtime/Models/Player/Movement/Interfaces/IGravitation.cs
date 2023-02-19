namespace Source.Runtime.Models.Player.Movement.Interfaces
{
    public interface IGravitation
    {
        bool CanGravitate { get; }
        void Gravitate(float deltaTime);
    }
}