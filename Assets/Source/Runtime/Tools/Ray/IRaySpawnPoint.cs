using UnityEngine;

namespace FPS.Tools
{
    public interface IRaySpawnPoint : IReadOnlyPosition
    {
        Vector3 Forward { get; }
    }
}