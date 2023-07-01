using UnityEngine;

namespace FPS.Toolkit
{
    public interface IMovement
    {
        IReadOnlyPosition Position { get; }
        void Move(Vector3 motion);
    }
}