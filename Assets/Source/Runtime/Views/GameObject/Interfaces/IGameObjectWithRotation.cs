using UnityEngine;

namespace FPS.Views
{
    public interface IGameObjectWithRotation
    {
        Vector3 Rotation { get; }
        void Rotate(Vector3 euler);
    }
}