using FPS.Data;
using FPS.Factories;
using FPS.GamePlay;
using UnityEngine;

namespace FPS.Core
{
    [DisallowMultipleComponent]
    public sealed class GameEntryPoint : MonoBehaviour
    {
        [SerializeField] private CharacterFactory _characterFactory;
        [SerializeField] private PlayerFactory _playerFactory;
        [SerializeField] private PlayerWeaponCollectionFactory _playerWeaponFactory;
        [SerializeField] private EnemySimulationFactory _enemySimulationFactory;

        private void Start()
        {
            var gameEngine = new GameEngine
            (
                new Data.Factories
                (
                    _characterFactory, 
                    _playerFactory, 
                    _playerWeaponFactory, 
                    _enemySimulationFactory
                )
            );
            
            new Game(gameEngine).Play();
        }
    }
}