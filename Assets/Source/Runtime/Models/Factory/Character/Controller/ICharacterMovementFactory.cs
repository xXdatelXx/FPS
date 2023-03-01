using FPS.Game;
using FPS.Model;

namespace FPS.Factories
{
    public interface ICharacterMovementFactory
    {
        ICharacterMovement Create(IReadOnlyGameTime time);
    }
}