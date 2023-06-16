using UnityEngine;

namespace FPS.Tools
{
    public interface IRotation
    {
        Vector3 Euler { get; }
        void Rotate(Vector3 euler);
    }
}