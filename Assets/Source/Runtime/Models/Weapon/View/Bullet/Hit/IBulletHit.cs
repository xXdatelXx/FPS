using FPS.Tools;
using UnityEngine;

namespace FPS.Model
{
    public interface IBulletHit : IPoolObject
    {
        void Update(Vector3 hit);
    }
}