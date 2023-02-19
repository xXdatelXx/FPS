using Source.Runtime.Tools.Math;

namespace Source.Runtime.Models.Weapons.Magazine
{
    public interface IReadOnlyMagazine
    {
        IntWithStandard Bullets { get; }
    }
}