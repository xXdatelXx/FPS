using UnityEngine;

namespace FPS.Tools
{
    public interface IPosition : IReadOnlyPosition
    {
        void TeleportTo(Vector3 position);
    }
}