using Cysharp.Threading.Tasks;

namespace FPS.Model
{
    public interface IWeaponTrigger
    {
        void Press();
        UniTask WaitUnPress();
    }
}