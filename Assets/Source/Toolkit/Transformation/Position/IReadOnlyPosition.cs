using UnityEngine;

namespace FPS.Toolkit
{
    public interface IReadOnlyPosition
    {
        Vector3 Value { get; }
        Vector3 Forward { get; }
    }
}