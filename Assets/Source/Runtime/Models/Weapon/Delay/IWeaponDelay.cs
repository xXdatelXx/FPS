using FPS.Tools;

namespace FPS.Model
{
    public interface IWeaponDelay : ITimerWithCanceling, IReadOnlyWeaponDelay
    { }
}