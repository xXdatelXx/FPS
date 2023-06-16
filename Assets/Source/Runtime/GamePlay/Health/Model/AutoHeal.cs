using FPS.Toolkit;
using FPS.Toolkit.GameLoop;

namespace FPS.Model
{
    public sealed class AutoHeal : IGameLoopObject
    {
        private readonly IHealthWithHeal _health;
        private readonly float _heal;

        public AutoHeal(IHealthWithHeal health, float heal)
        {
            _health = health.ThrowExceptionIfArgumentNull(nameof(health));
            _heal = heal.ThrowExceptionIfValueSubZero(nameof(heal));
        }

        public void Tick(float deltaTime)
        {
            if (_health.CanHeal)
                _health.Heal(_heal);
        }
    }
}