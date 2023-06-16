namespace FPS.Model
{
    public interface IDamageCoefficient
    {
        float Next(float distance);
    }
}