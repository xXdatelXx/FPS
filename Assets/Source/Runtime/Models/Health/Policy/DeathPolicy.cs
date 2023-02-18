namespace Source.Runtime.Model.Health
{
    public sealed class DeathPolicy : IDeathPolicy
    {
        public bool Died(float health) => health <= 0;
    }
}