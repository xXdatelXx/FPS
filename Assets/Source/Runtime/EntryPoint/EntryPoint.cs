using Source.Runtime.CompositeRoot;
using Source.Runtime.CompositeRoot.Weapons;
using Source.Runtime.Data;
using UnityEngine;

namespace Source.Runtime.EntryPoint
{
    [DisallowMultipleComponent]
    public sealed class EntryPoint : MonoBehaviour
    {
        [SerializeField] private PlayerFactory _playerFactory;
        [SerializeField] private PlayerWeaponCollectionFactory _playerWeaponFactory;

        private void Awake()
        {
            var gameEngine = new GameEngine(_playerFactory, _playerWeaponFactory);
            new Game(gameEngine).Play();
        }
    }
}