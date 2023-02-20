using UnityEngine;

namespace Source.Runtime.Views.GameObject
{
    public interface IGameObjectWithRotation
    {
        Vector3 Rotation { get; }
        void Rotate(Vector3 euler);
    }
}