using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class EnemySimulationFactory : MonoBehaviour, IEnemySimulationFactory
    {
        [SerializeField] private Enemy _prefab;
        [SerializeField] private Timer _spawnTimer;
        [SerializeField] private Range _enemySpawnPositionRange;
        [SerializeField] private Vector2 _levelBound;

        public IEnemySimulation Create(ICharacter character)
        {
            character.ThrowExceptionIfArgumentNull(nameof(character));
            
            var enemyFactory = new EnemyFactory(_prefab, character, _enemySpawnPositionRange, _levelBound);
            return new EnemySimulation(enemyFactory, _spawnTimer);
        }
    }
}