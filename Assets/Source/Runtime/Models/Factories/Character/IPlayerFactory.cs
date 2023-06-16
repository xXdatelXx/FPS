using FPS.Model;
using FPS.Tools.GameLoop;

namespace FPS.Factories
{
    public interface IPlayerFactory
    {
        IPlayer Create(IReadOnlyGameTime time);
    }
}