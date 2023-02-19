using Source.Runtime.Models.Player.Rotation;

namespace Source.Runtime.Models.Factory.Character.Controller
{
    public interface ICharacterRotationFactory
    {
        ICharacterRotation Create();
    }
}