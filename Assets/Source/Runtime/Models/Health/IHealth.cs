namespace Source.Runtime.Models.Health
{
    public interface IHealth
    {
        bool Died { get; }
        void TakeDamage(float damage);
    }
}