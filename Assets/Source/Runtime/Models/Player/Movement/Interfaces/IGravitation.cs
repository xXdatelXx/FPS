namespace FPS.Model
{
    public interface IGravitation
    {
        bool CanGravitate { get; }
        void Gravitate(float deltaTime);
    }
}