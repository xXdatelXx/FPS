using UnityEngine;

namespace FPS.Toolkit
{
    public interface IPosition : IReadOnlyPosition
    {
        void TeleportTo(Vector3 position);
    }
}