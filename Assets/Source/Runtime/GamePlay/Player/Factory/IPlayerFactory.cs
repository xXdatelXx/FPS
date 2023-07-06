using FPS.GamePlay;
using FPS.Toolkit.GameLoop;

namespace FPS.Factories
{
    public interface IPlayerFactory
    {
        IPlayer Create(ICharacter character);
    }
}