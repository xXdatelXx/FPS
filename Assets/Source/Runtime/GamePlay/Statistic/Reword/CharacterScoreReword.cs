using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class CharacterScoreReword : IReword
    {
        private readonly ICharacterScore _score;

        public CharacterScoreReword(ICharacterScore score) => 
            _score = score.ThrowExceptionIfArgumentNull(nameof(score));

        public void Receive() => 
            _score.IncreaseKill();
    }
}