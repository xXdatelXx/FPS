using FPS.Model;
using Source.Runtime.Models.Loop;

namespace Source.Runtime.CompositeRoot
{
    public interface IPlayerFactory
    {
        IPlayer Create(IReadOnlyGameTime time);
    }
}