namespace Source.Runtime.Models.HealthSystem.Policy
{
    public sealed class DeathPolicy : IDeathPolicy
    {
        public bool Died(float health) =>
            health <= 0;
    }
}