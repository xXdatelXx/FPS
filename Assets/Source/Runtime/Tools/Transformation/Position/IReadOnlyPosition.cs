using UnityEngine;

namespace FPS.Tools
{
    public interface IReadOnlyPosition
    {
        Vector3 Value { get; }
    }
}