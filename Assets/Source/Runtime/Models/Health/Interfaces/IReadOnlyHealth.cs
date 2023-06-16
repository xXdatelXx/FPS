namespace FPS.Model
{
    public interface IReadOnlyHealth
    {
        bool Died { get; }
        float Points { get; }
    }
}