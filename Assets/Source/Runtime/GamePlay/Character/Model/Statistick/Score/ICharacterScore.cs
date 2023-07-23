namespace FPS.GamePlay
{
    public interface ICharacterScore : IReadOnlyCharacterScore
    {
        void IncreaseKill();
    }
}