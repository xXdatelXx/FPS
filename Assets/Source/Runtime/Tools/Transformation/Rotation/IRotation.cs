using UnityEngine;

namespace FPS.Tools
{
    public interface IRotation
    {
        Vector3 Value { get; }
        void Rotate(Vector3 euler);
    }
}