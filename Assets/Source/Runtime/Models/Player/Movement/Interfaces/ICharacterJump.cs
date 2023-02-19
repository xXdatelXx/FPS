namespace Source.Runtime.Models.Player.Movement.Interfaces
{
    public interface ICharacterJump
    {
        bool Jumping { get; }
        bool CanJump { get; }

        void Jump();
    }
}