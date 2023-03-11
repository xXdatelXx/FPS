using Cysharp.Threading.Tasks;
using UnityEngine;

namespace FPS.Model
{
    public interface IBulletRay
    {
        void Cast();
        void Cast(Vector3 target);
        UniTask End();
    }
}