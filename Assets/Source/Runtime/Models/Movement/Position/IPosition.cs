using UnityEngine;

namespace FPS.Model
{
    public interface IPosition
    {
        Vector3 World { get; }
        Vector3 Local { get; }
    }
}