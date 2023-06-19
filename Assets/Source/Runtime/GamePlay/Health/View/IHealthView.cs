namespace FPS.GamePlay
{
    public interface IHealthView
    {
        void Visualize(float health);
        void Die();
    }
}