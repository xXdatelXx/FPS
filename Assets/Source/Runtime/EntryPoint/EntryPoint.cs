using FPS.Data;
using FPS.Factories;
using UnityEngine;

namespace FPS.EntryPoint
{
    [DisallowMultipleComponent]
    public sealed class EntryPoint : MonoBehaviour
    {
        [SerializeField] private PlayerFactory _playerFactory;
        [SerializeField] private PlayerWeaponCollectionFactory _playerWeaponFactory;

        private void Start()
        {
            var gameEngine = new GameEngine(_playerFactory, _playerWeaponFactory);
            new Game.Game(gameEngine).Play();
        }
    }
}