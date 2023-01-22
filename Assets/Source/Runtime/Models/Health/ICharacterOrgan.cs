namespace Source.Runtime.Model.Health
{
    public interface ICharacterOrgan : IHealth
    {
        void Construct(IHealth health, float multiplier);
    }
}