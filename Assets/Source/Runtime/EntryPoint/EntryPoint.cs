using Sirenix.OdinInspector;
using Source.Runtime.CompositeRoot.Weapons;
using UnityEngine;

namespace Source.Runtime.CompositeRoot
{
    [DisallowMultipleComponent]
    public sealed class EntryPoint : SerializedMonoBehaviour
    {
        [SerializeField] private IPlayerFactory _playerFactory;
        [SerializeField] private IPlayerWeaponFactory _playerWeaponFactory;
        
        private void Awake()
        {
            var gameEngine = new GameEngine(_playerFactory, _playerWeaponFactory);
            new Game(gameEngine).Play();
        }
    }
}