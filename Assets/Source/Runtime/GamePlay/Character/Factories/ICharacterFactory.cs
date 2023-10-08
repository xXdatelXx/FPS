using FPS.GamePlay;
using FPS.Toolkit.GameLoop;

namespace FPS.Factories
{
    public interface ICharacterFactory
    {
        ICharacter Create(IReadOnlyGameTime time);
    }
}