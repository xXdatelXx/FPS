using System;
using FPS.Toolkit;

namespace FPS.GamePlay
{
    public sealed class EnemySimulation : IEnemySimulation
    {
        private readonly IFactory<Enemy> _factory;
        private readonly ITimer _spawnTimer;

        public EnemySimulation(IFactory<Enemy> factory, ITimer spawnTimer)
        {
            _factory = factory.ThrowExceptionIfArgumentNull(nameof(factory));
            _spawnTimer = spawnTimer.ThrowExceptionIfArgumentNull(nameof(spawnTimer));
        }

        public void Start()
        {
            if (_spawnTimer.Playing)
                throw new InvalidOperationException(nameof(Start));

            _spawnTimer.Play();
        }

        public void Tick(float deltaTime)
        {
            if (_spawnTimer.Playing)
                return;

            _spawnTimer.Play();
            _factory.Create();
        }
    }
}