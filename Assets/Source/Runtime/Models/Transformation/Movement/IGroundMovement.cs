namespace FPS.Model
{
    public interface IGroundMovement : IMovement
    {
        bool Grounded { get; }
    }
}