﻿using FPS.Model;
using FPS.Tools;
using FPS.Tools.GameLoop;
using UnityEngine;

namespace FPS.Factories
{
    public sealed class BulletViewFactory : MonoBehaviour, IFactory<IBulletView>
    {
        [SerializeField] private ParticleSystem _startBulletParticle;
        [SerializeField] private CrosshairFactory _crosshairFactory;
        [SerializeField] private BulletHitFactory _bulletHitFactory;
        [SerializeField] private BulletRayFactory _bulletRayFactory;
        [SerializeField] private float _rayWorkTime;
        private IGameLoopObjects _rays;

        private void Awake()
        {
            _rays = new GameLoopObjects();
            new GameLoop(new GameTime(), _rays).Start();
        }

        public IBulletView Create() =>
            new BulletView(new BulletParticle(_startBulletParticle), CreateHitsView(), CreateRays(), _crosshairFactory.Create());

        private IBulletRay CreateRays() =>
            new BulletRays(new Pool<IBulletRay>(_bulletRayFactory), new TimerFactory(_rayWorkTime, _rays));

        private IBulletHitView CreateHitsView() =>
            new BulletHitsView(new Pool<IBulletHitView>(_bulletHitFactory), 100);
    }
}