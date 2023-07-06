using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class EnemySimulationFactory : MonoBehaviour, IEnemySimulationFactory
    {
        [SerializeField] private Enemy _prefab;
        [SerializeField] private Timer _spawnTimer;

        public IEnemySimulation Create(ICharacter character)
        {
            character.ThrowExceptionIfArgumentNull(nameof(character));
            return new EnemySimulation(new EnemyFactory(_prefab, character), _spawnTimer);
        }
    }
}