using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public interface IBulletHitView : IPoolObject
    {
        void Update(Vector3 hit);
    }
}