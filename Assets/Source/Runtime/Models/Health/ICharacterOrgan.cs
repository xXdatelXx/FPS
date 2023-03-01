namespace FPS.Model
{
    public interface ICharacterOrgan : IHealth
    {
        void Construct(IHealth health, float multiplier);
    }
}