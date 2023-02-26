namespace Source.Runtime.Models.HealthSystem.Policy
{
    public interface IDeathPolicy
    {
        bool Died(float health);
    }
}