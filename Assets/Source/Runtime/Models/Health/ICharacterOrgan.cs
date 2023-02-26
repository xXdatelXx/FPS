namespace Source.Runtime.Models.HealthSystem
{
    public interface ICharacterOrgan : IHealth
    {
        void Construct(IHealth health, float multiplier);
    }
}