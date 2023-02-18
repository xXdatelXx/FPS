namespace Source.Runtime.Model.Health.Views
{
    public interface IHealthView
    {
        void Damage(float health);
        void Die();
    }
}