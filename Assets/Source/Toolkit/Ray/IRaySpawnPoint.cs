using UnityEngine;

namespace FPS.Toolkit
{
    public interface IRaySpawnPoint : IReadOnlyPosition
    {
        Vector3 Forward { get; }
    }
}