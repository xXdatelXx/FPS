using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public sealed class BulletViewFactory : MonoBehaviour, IFactory<IBulletView>
    {
        [SerializeField] private ParticleSystem _startBulletParticle;
        [SerializeField] private CrosshairFactory _crosshairFactory;
        [SerializeField] private BulletHitFactory _bulletHitFactory;
        [SerializeField] private BulletRayFactory _bulletRayFactory;
        [SerializeField] private float _rayWorkTime;
        
        public IBulletView Create() => 
            new BulletView(new BulletParticle(_startBulletParticle), CreateHitsView(), CreateRays(), _crosshairFactory.Create());

        private IBulletRay CreateRays() => 
            new BulletRays(new Pool<IBulletRay>(_bulletRayFactory), new TimerFactory(_rayWorkTime));

        private IBulletHitView CreateHitsView() => 
            new BulletHitsView(100, new Pool<IBulletHitView>(_bulletHitFactory));
    }
}