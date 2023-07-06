using FPS.Input;
using FPS.GamePlay;
using FPS.Toolkit.GameLoop;
using UnityEngine;

namespace FPS.Factories
{
    public sealed class PlayerFactory : MonoBehaviour, IPlayerFactory
    {
        public IPlayer Create(ICharacter character) => 
            new Player(character, new PlayerMovementInput());
    }
}