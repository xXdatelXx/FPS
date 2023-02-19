namespace Source.Runtime.Models.Health.Views
{
    public interface IHealthView
    {
        void Damage(float health);
        void Die();
    }
}