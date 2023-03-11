using UnityEngine;

namespace FPS.Tools
{
    public interface IGameObjectWithMovement
    {
        Vector3 Position { get; }
        void MoveTo(Vector3 point);
    }
}