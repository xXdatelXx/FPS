using UnityEngine;

namespace FPS.Model
{
    public interface IBulletHitView
    {
        void Visualize(Vector3 target, Vector3 normal);
        void Hide();
    }
}