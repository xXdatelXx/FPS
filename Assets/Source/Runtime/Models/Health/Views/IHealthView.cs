namespace FPS.Model
{
    public interface IHealthView
    {
        void Visualize(float health);
        void Die();
    }
}