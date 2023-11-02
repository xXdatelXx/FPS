namespace FPS.Input
{
    public interface IMouseSensitivity : IReadOnlyMouseSensitivity
    {
        void Update(float value);
    }
}