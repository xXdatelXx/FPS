using Source.Runtime.Models.Game.Loop.Time;
using Source.Runtime.Models.Player.Movement.Interfaces;

namespace Source.Runtime.Models.Factory.Character.Controller
{
    public interface ICharacterMovementFactory
    {
        ICharacterMovement Create(IReadOnlyGameTime time);
    }
}