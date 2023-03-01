namespace FPS.Model
{
    public sealed class DeathPolicy : IDeathPolicy
    {
        public bool Died(float health) =>
            health <= 0;
    }
}