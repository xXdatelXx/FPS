using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class HealthWithReward : IHealth
    {
        private readonly IHealth _health;
        private readonly IReward _reward;

        public HealthWithReward(IHealth health, IReward reward)
        {
            _health = health.ThrowExceptionIfArgumentNull(nameof(health));
            _reward = reward.ThrowExceptionIfArgumentNull(nameof(reward));
        }

        public bool Died => _health.Died;
        public float Points => _health.Points;

        public void TakeDamage(float damage)
        {
            if (_health.Died)
                return;

            _health.TakeDamage(damage);
            
            if (_health.Died)
                _reward.Receive();
        }
    }
}