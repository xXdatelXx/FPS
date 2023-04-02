using UnityEngine;

namespace FPS.Model
{
    public interface IPositionWithVectorTransform : IPosition
    {
        Vector3 TransformVector(Vector3 vector);
        Vector3 TransformPoint(Vector3 vector);
        Vector3 TransformDirection(Vector3 vector);
    }
}