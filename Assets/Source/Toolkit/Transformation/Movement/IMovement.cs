using UnityEngine;

namespace FPS.Toolkit
{
    public interface IMovement
    {
        Vector3 Position { get; }
        void Move(Vector3 motion);
    }
}