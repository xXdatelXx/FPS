using FPS.Model;
using Source.Runtime.Models.Loop;

namespace Source.Runtime.CompositeRoot
{
    public interface ICharacterMovementFactory
    {
        ICharacterMovement Create(IReadOnlyGameTime time);
    }
}