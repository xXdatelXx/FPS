using FPS.Model;
using FPS.Toolkit.GameLoop;

namespace FPS.Factories
{
    public interface ICharacterMovementFactory
    {
        ICharacterMovement Create(IReadOnlyGameTime time);
    }
}