using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class ScoreReward : IReward
    {
        private readonly IScore _score;
        private readonly int _reward;

        public ScoreReward(IScore score, int reword)
        {
            _score = score.ThrowExceptionIfArgumentNull(nameof(score));
            _reward = reword.ThrowExceptionIfValueSubZero(nameof(reword));
        }

        public void Receive() =>
            _score.Increase(_reward);
    }
}