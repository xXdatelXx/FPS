using FPS.GamePlay;
using FPS.Toolkit;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FPS.Data
{
    [CreateAssetMenu(menuName = nameof(EnemySimulationConfig))]
    public sealed class EnemySimulationConfig : ScriptableObject
    {
        [field: SerializeField] public Enemy Enemy { get; private set; }
        [field: SerializeField, MinValue(0)] public int EnemyKillReword { get; private set; }
        [field: SerializeField, MinValue(0)] public float SpawnTime { get; private set; }
        [field: SerializeField] public Range SpawnDistanceFromCharacterDiapason { get; private set; }
        
    }
}