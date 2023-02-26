namespace Source.Runtime.Models.HealthSystem
{
    public interface IHealth
    {
        bool Died { get; }
        void TakeDamage(float damage);
    }
}