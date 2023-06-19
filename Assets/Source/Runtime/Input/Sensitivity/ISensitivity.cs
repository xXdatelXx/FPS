using UnityEngine;

namespace FPS.Input
{
    public interface ISensitivity : IReadOnlySensitivity
    {
        void Update(Vector2 value);
    }
}