using UnityEngine;

namespace FPS.GamePlay
{
    public interface IBulletHitView
    {
        void Visualize(Vector3 target);
        void Hide();
    }
}