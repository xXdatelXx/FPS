namespace Source.Runtime.Model.Health.Views
{
    public sealed class DummyHealthView : IHealthView
    {
        public void Damage(float health)
        { }

        public void Die()
        { }
    }
}