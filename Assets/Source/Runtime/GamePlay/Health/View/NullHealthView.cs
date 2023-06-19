namespace FPS.GamePlay
{
    public sealed class NullHealthView : IHealthView
    {
        public void Visualize(float health)
        {
        }

        public void Die()
        {
        }
    }
}