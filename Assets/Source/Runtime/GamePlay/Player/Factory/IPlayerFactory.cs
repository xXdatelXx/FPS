using FPS.GamePlay;

namespace FPS.Factories
{
    public interface IPlayerFactory
    {
        IPlayer Create(ICharacter character);
    }
}