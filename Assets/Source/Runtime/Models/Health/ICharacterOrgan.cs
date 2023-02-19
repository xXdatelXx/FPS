namespace Source.Runtime.Models.Health
{
    public interface ICharacterOrgan : IHealth
    {
        void Construct(IHealth health, float multiplier);
    }
}