namespace FPS.GamePlay
{
    public sealed class NullHealthView : IHealthView
    {
        public void Damage(float health)
        {
        }

        public void Heal(float health)
        {
        }

        public void Die()
        {
        }
    }
}