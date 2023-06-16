using UnityEngine;

namespace FPS.Model
{
    public interface IBulletHitView
    {
        void Visualize(Vector3 target);
        void Hide();
    }
}