namespace Source.Runtime.Models.HealthSystem.Views
{
    public interface IHealthView
    {
        void Visualize(float health);
        void Die();
    }
}