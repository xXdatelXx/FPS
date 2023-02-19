namespace Source.Runtime.Models.Health.Policy
{
    public interface IDeathPolicy
    {
        bool Died(float health);
    }
}