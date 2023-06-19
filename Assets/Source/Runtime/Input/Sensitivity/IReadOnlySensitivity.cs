using UnityEngine;

namespace FPS.Input
{
    public interface IReadOnlySensitivity
    {
        Vector2 Value { get; }
    }
}