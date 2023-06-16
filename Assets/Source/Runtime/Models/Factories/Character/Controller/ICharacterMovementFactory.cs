using FPS.Model;
using FPS.Tools.GameLoop;

namespace FPS.Factories
{
    public interface ICharacterMovementFactory
    {
        ICharacterMovement Create(IReadOnlyGameTime time);
    }
}