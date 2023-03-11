using UnityEngine;

namespace FPS.Model
{
    public interface IBulletHitsView
    {
        void Visualize(Vector3 target, Vector3 normal);
    }
}