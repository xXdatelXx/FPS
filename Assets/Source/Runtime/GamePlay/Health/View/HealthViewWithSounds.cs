using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class HealthViewWithSounds : IHealthView
    {
        private readonly IHealthView _view;
        private readonly ISound _damage;
        private readonly ISound _die;

        public HealthViewWithSounds(IHealthView view, ISound damage, ISound die)
        {
            _view = view.ThrowExceptionIfArgumentNull(nameof(view));
            _damage = damage.ThrowExceptionIfArgumentNull(nameof(damage));
            _die = die.ThrowExceptionIfArgumentNull(nameof(die));
        }
        
        public void Damage(float health)
        {
            _damage.Play();
            _view.Damage(health);
        }

        public void Heal(float health) => 
            _view.Heal(health);

        public void Die()
        {
            _die.Play();
            _view.Die();
        }
    }
}