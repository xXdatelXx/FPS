using FPS.GamePlay;
using FPS.Toolkit.GameLoop;

namespace FPS.Factories
{
    public interface ICharacterMovementFactory
    {
        ICharacterMovement Create(IReadOnlyGameTime time);
    }
}