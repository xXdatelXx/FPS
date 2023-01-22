using Sirenix.OdinInspector;
using UnityEngine;

namespace Source.Runtime.CompositeRoot
{
    public sealed class EntryPoint : SerializedMonoBehaviour
    {
        [SerializeField] private IPlayerFactory _playerFactory;
        
        private void Awake()
        {
            var gameEngine = new GameEngine(_playerFactory);
            new Game(gameEngine).Play();   
        }
    }
}