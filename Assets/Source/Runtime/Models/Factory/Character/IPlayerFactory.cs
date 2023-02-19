using Source.Runtime.Models.Game.Loop.Time;
using Source.Runtime.Models.Player;

namespace Source.Runtime.Models.Factory.Character
{
    public interface IPlayerFactory
    {
        IPlayer Create(IReadOnlyGameTime time);
    }
}