namespace FPS.Model
{
    public interface ICharacter
    {
        ICharacterOrgan Head { get; }
        ICharacterOrgan Body { get; }
    }
}