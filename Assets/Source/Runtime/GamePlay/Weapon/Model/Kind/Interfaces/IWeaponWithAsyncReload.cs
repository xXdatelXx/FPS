using Cysharp.Threading.Tasks;

namespace FPS.GamePlay
{
    //I don't know is it good idea
    public interface IWeaponWithAsyncReload : IWeaponWithMagazine
    {
        UniTask ReloadAsync();
    }
}