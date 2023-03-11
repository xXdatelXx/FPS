using FPS.Tools;
using Source.Runtime.Models.Factories.Weapon;
using UnityEngine;

namespace FPS.Model
{
    public sealed class BulletViewFactory : MonoBehaviour, IFactory<IBulletView>
    {
        [SerializeField] private ParticleSystem _startBulletParticle;
        [SerializeField] private CrosshairFactory _crosshairFactory;
        [SerializeField] private BulletHitFactory _bulletHitFactory;
        [SerializeField] private BulletRayFactory _bulletRayFactory;

        public IBulletView Create() => 
            new BulletView(new BulletParticle(_startBulletParticle), CreateHitsView(), CreateRays(), _crosshairFactory.Create());

        private IBulletRays CreateRays() => 
            new BulletRays(new Pool<IBulletRay>(_bulletRayFactory));

        private IBulletHitsView CreateHitsView() => 
            new BulletHitsView(100, new Pool<IBulletHitView>(_bulletHitFactory));
    }
}