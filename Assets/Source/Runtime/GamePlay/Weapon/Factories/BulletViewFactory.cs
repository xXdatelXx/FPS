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
        [SerializeField] private float _rayWorkTime;
        private IGameLoopObjects _rays;

        private void Awake()
        {
            _rays = new GameLoopObjects();
            new GameLoop(new GameTime(), _rays).Start();
        }

        public IBulletView Create() =>
            new BulletView(new BulletParticle(_startBulletParticle), CreateHitsView(), CreateRays(), _crosshairFactory.Create());

        private IBulletTrace CreateRays() =>
            new BulletTraces(new Pool<IBulletTrace>(_bulletTraceFactory), new TimerFactory(_rayWorkTime, _rays));

        private IBulletHitView CreateHitsView() =>
            new BulletHitsView(new Pool<IBulletHitView>(_bulletHitFactory), 100);
    }
}