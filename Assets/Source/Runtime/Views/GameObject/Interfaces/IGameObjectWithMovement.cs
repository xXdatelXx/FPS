using UnityEngine;

namespace FPS.Views
{
    public interface IGameObjectWithMovement
    {
        void MoveTo(Vector3 point);
    }
}