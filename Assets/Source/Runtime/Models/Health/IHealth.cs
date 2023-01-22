namespace Source.Runtime.Model.Health
{
    public interface IHealth
    {
        bool Died { get; }
        void TakeDamage(float damage);
    }
}