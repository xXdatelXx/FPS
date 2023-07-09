﻿using FPS.Toolkit;
using UnityEngine;
using Range = FPS.Toolkit.Range;

namespace FPS.GamePlay
{
    public sealed class EnemySimulationFactory : MonoBehaviour, IEnemySimulationFactory
    {
        [SerializeField] private Enemy _prefab;
        [SerializeField, Range(0, 200)] private int _healthPoint;
        [SerializeField] private Timer _spawnTimer;
        [SerializeField] private Range _enemySpawnPositionRange;
        [SerializeField] private Transform _parent;

        public IEnemySimulation Create(ICharacter character)
        {
            character.ThrowExceptionIfArgumentNull(nameof(character));

            var enemyFactory = new EnemyFactory(_prefab, new Health(_healthPoint), character, _enemySpawnPositionRange, _parent);
            return new EnemySimulation(enemyFactory, _spawnTimer);
        }

        private void Update() => _spawnTimer.Tick(Time.deltaTime);
    }
}