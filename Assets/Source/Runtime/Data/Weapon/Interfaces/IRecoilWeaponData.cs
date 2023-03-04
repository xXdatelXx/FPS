using UnityEngine;

namespace FPS.Data
{
    public interface IRecoilWeaponData : IWeaponData
    {
        AnimationCurve RecoilCurve { get; }
    }
}