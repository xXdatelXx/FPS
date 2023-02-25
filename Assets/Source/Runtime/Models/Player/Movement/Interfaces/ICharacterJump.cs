using Source.Runtime.Models.Game.Loop.Tickables;

namespace Source.Runtime.Models.Player.Movement.Interfaces
{
    public interface ICharacterJump : ITickable
    {
        bool Jumping { get; }
        bool CanJump { get; }

        void Jump();
    }
}