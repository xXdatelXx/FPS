using FPS.Toolkit;

namespace FPS.Model
{
    public interface IWeaponDelay : ITimerWithCanceling, IReadOnlyWeaponDelay
    { }
}