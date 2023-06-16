using UnityEngine;

namespace FPS.Toolkit
{
    public interface IRotation
    {
        Vector3 Euler { get; }
        void Rotate(Vector3 euler);
    }
}