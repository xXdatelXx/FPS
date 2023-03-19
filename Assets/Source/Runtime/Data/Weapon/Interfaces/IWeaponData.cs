using UnityEngine;

namespace FPS.Data
{
    public interface IWeaponData
    {
        float Damage { get; }
        AnimationCurve DamageCurve { get; }
    }
}