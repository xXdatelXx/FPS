using FPS.Game;
using FPS.Model;

namespace FPS.Factories
{
    public interface IPlayerFactory
    {
        IPlayer Create(IReadOnlyGameTime time);
    }
}