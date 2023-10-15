using FPS.GamePlay;
using FPS.Toolkit;
using FPS.Toolkit.GameLoop;
using UnityEngine;

namespace FPS.Factories
{
    public sealed class BulletViewFactory : MonoBehaviour, IFactory<IBulletView>
    {
        [SerializeField] private ParticleSystem _startBulletParticle;
        [SerializeField] private CrosshairFactory _crosshairFactory;
        [SerializeField] private BulletHitFactory _bulletHitFactory;
        [SerializeField] private BulletTraceFactory _bulletTraceFactory;
        [SerializeField] private float _rayLifeTime;
        [SerializeField] private float _hitsLifeTime;
        private IGameLoopObjects _bulletsEffects;

        private void Awake()
        {
            _bulletsEffects = new GameLoopObjects();
            new GameLoop(new GameTime(), _bulletsEffects).Start();
        }

        public IBulletView Create()
        {
            var tracesPool = new Pool<IBulletTrace>(_bulletTraceFactory);
            var tracesLifeTimers = new TimerFactory(_rayLifeTime, _bulletsEffects);

            var hitsPool = new Pool<IBulletHitView>(_bulletHitFactory);
            var hitsLifeTimers = new TimerFactory(_hitsLifeTime, _bulletsEffects);
            
            return new BulletViewSequence
            (
     new BulletViewWithCrosshair(_crosshairFactory.Create()),
                new BulletViewWithTrace(tracesPool, tracesLifeTimers),
                new BulletViewWithHitEffect(hitsPool, hitsLifeTimers),
                new BulletViewWithShootParticle(new BulletParticle(_startBulletParticle))
            );
        }
    }
}