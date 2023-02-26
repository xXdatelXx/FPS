using Source.Runtime.Input;
using Source.Runtime.Models.Factory.Character.Controller;
using Source.Runtime.Models.Factory.Character.Healths;
using Source.Runtime.Models.Game.Loop.Time;
using Source.Runtime.Models.Player;
using UnityEngine;

namespace Source.Runtime.Models.Factory.Character
{
    public sealed class PlayerFactory : MonoBehaviour, IPlayerFactory
    {
        [SerializeField] private CharacterMovementFactory _movement;
        [SerializeField] private CharacterRotationFactory _rotation;
        [SerializeField] private CharacterHealthFactory _health;

        public IPlayer Create(IReadOnlyGameTime time)
        {
            _health.Create();
            return new Player.Player(_movement.Create(time), _rotation.Create(), new PlayerMovementInput());
        }
    }
}