using UnityEngine;

namespace FPS.Tools
{
    public interface IRayHit
    {
        Vector3 Point { get; }
        Vector3 Normal { get; }
        float Distance { get; }
        bool Is<T>(out T t);
    }
}