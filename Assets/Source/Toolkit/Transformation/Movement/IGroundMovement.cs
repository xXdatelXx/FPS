namespace FPS.Toolkit
{
    public interface IGroundMovement : IMovement
    {
        bool Grounded { get; }
    }
}