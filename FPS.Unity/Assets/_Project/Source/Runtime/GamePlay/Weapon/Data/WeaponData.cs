using UnityEngine;

namespace FPS.Data
{
    [CreateAssetMenu(menuName = nameof(WeaponData))]
    public sealed class WeaponData : ScriptableObject
    {
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public AnimationCurve DamageCurve { get; private set; }
        [field: SerializeField] public float Reload { get; private set; }
        [field: SerializeField] public int Bullets { get; private set; }
        [field: SerializeField] public float Delay { get; private set; }
        [field: SerializeField] public float Enable { get; private set; }
        [field: SerializeField] public AnimationCurve RecoilCurve { get; private set; }
    }
}