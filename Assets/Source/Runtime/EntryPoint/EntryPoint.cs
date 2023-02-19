using Source.Runtime.Data;
using Source.Runtime.Models.Factory.Character;
using Source.Runtime.Models.Factory.Character.Weapon;
using Source.Runtime.Models.Game;
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