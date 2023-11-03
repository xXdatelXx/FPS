using Sirenix.OdinInspector;
using UnityEngine;

namespace FPS.Data
{
    [CreateAssetMenu(menuName = nameof(CharacterConfig))]
    public sealed class CharacterConfig : ScriptableObject
    {
        [field: SerializeField, MinValue(0)] public float Health { get; private set; }
        [field: SerializeField, MinValue(0)] public float HealPerTick { get; private set; }
        [field: SerializeField, MinValue(0)] public float Speed { get; private set; }
        [field: SerializeField] public AnimationCurve JumpMotion { get; private set; }
    }
}