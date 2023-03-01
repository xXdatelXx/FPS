namespace FPS.Model
{
    public interface IDeathPolicy
    {
        bool Died(float health);
    }
}