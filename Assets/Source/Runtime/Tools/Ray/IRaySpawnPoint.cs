using UnityEngine;

namespace FPS.Tools
{
    public interface IRaySpawnPoint
    {
        Vector3 Position { get; }
        Vector3 Forward { get; }
    }
}