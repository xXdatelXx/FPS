using UnityEngine;

namespace FPS.Model
{
    public interface IMovement
    {
        bool Grounded { get; }
        void Move(Vector3 motion);
        void MoveByRotation(Vector3 motion);
    }
}