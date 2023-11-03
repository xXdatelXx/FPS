using FPS.Data;
using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class EnemySimulationFactory : MonoBehaviour, IEnemySimulationFactory
    {
        [SerializeField] private EnemySimulationConfig _config;
        [SerializeField] private Transform _parent;
        private Timer _spawnTimer;

        private void OnValidate() => 
            _spawnTimer = new Timer(_config.SpawnTime);

        public IEnemySimulation Create(ICharacter character)
        {
            character.ThrowExceptionIfArgumentNull(nameof(character));

            var enemyKillReword = new ScoreReward(character.Score, _config.EnemyKillReword);
            var enemyFactory = 
                new EnemyFactory(_config.Enemy, character, _config.SpawnDistanceFromCharacterDiapason, enemyKillReword, _parent);
           
            return new EnemySimulation(enemyFactory, _spawnTimer);
        }

        private void Update() => _spawnTimer.Tick(Time.deltaTime);
    }
}