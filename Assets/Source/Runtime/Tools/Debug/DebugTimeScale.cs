using UnityEditor;
using UnityEngine;

namespace FPS.Tools.Debug
{
    public static class DebugTimeScale
    {
#if UNITY_EDITOR

        [MenuItem("Custom/DebugTimeScale")]
        private static void SwitchToDebug() => Time.timeScale = 0.1f;

        [MenuItem("Custom/NormalTimeScale")]
        private static void SwitchToNormal() => Time.timeScale = 1;

#endif
    }
}