using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class BulletViewWithSounds : IBulletView
    {
        private readonly IBulletView _view;
        private readonly ISound _kill;
        private readonly ISound _damage;

        public BulletViewWithSounds(IBulletView view, ISound kill, ISound damage)
        {
            _view = view.ThrowExceptionIfArgumentNull(nameof(view));
            _kill = kill.ThrowExceptionIfArgumentNull(nameof(kill));
            _damage = damage.ThrowExceptionIfArgumentNull(nameof(damage));
        }

        public BulletViewWithSounds(ISound kill, ISound damage) : this(new NullBulletView(), kill, damage)
        { }

        public void Miss() => _view.Miss();

        public void Hit(Vector3 target) => _view.Hit(target);

        public void Kill()
        {
            _view.Kill();
            _kill.Play();
        }

        public void Damage()
        {
            _view.Damage();
            _damage.Play();
        }
    }
}