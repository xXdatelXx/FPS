using UnityEngine;

namespace FPS.Tools
{
    public sealed class RaySpawnPoint : MonoBehaviour, IRaySpawnPoint
    {
        public Vector3 Value => transform.position;
        public Vector3 Forward => transform.forward;
    }
}