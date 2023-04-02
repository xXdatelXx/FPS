using UnityEngine;

namespace FPS.Tools
{
    public interface IGameObjectWithRotation
    {
        Vector3 Rotation { get; }
        void Rotate(Vector3 euler);
    }
}