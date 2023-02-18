namespace Source.Runtime.Model.Health
{
    public interface IDeathPolicy
    {
        bool Died(float health);
    }
}