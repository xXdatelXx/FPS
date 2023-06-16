using UnityEngine;

namespace FPS.Tools
{
    public interface IPositionWithVectorTransform : IReadOnlyPosition
    {
        Vector3 TransformVector(Vector3 vector);
        Vector3 TransformPoint(Vector3 vector);
        Vector3 TransformDirection(Vector3 vector);
    }
}