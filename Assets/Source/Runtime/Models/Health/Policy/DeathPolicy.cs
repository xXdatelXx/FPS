namespace Source.Runtime.Models.Health.Policy
{
    public sealed class DeathPolicy : IDeathPolicy
    {
        public bool Died(float health) => 
            health <= 0;
    }
}