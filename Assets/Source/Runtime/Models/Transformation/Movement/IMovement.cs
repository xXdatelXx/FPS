using UnityEngine;

namespace FPS.Model
{
    public interface IMovement
    {
        Vector3 Position { get; }
        void Move(Vector3 motion);
        void MoveByRotation(Vector3 motion);
    }
}