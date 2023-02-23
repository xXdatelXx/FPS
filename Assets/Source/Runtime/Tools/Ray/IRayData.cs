using UnityEngine;

namespace Source.Runtime.Tools.Ray
{
    public interface IRayData<out TTarget>
    {
        Vector3 Point { get; }
        float Distance { get; }
        TTarget Target { get; }
    }
}