using Source.Runtime.Tools.Math;

namespace FPS.Model.Weapons.Bullet
{
    public interface IReadOnlyMagazine
    {
        IntWithStandard Bullets { get; }
    }
}