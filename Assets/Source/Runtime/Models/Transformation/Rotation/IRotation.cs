using UnityEngine;

namespace FPS.Model
{
    public interface IRotation
    {
        Vector3 Value { get; }
        void Rotate(Vector3 euler);
    }
}