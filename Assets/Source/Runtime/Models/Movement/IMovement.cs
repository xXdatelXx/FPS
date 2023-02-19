using UnityEngine;

namespace Source.Runtime.Models.Movement
{
    public interface IMovement
    {
        bool Grounded { get; }
        void Move(Vector3 motion);
        void MoveByRotation(Vector3 motion);
    }
}