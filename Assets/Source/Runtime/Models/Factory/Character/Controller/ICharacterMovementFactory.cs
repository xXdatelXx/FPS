using FPS.Model;

namespace Source.Runtime.CompositeRoot
{
    public interface ICharacterMovementFactory
    {
        ICharacterMovement Create();
    }
}