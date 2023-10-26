using Cysharp.Threading.Tasks;
using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class BulletViewWithTrace : IBulletView
    {
        private readonly IBulletView _bullet;
        private readonly IFactory<IBulletTrace> _factory;
        
        public BulletViewWithTrace(IBulletView bullet, IFactory<IBulletTrace> factory)
        {
            _bullet = bullet.ThrowExceptionIfArgumentNull(nameof(bullet));
            _factory = factory.ThrowExceptionIfArgumentNull(nameof(factory));
        }
        
        public BulletViewWithTrace(IFactory<IBulletTrace> factory) : this(new NullBulletView(), factory)
        { }

        public void Miss()
        {
            _bullet.Miss();
            
            var trace = _factory.Create();
            trace.Cast();
        }

        public void Hit(Vector3 target)
        {
            _bullet.Hit(target);
            
            var trace = _factory.Create();
            trace.Cast(target);
        }
        
        public void Kill() => _bullet.Kill();

        public void Damage() => _bullet.Damage();
    }
}