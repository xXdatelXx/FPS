using System;
using FPS.Tools;
using Object = UnityEngine.Object;

namespace FPS.Tools
{
    public sealed class GameObject : IGameObject
    {
        private readonly UnityEngine.GameObject _object;

        public GameObject(UnityEngine.GameObject obj) =>
            _object = obj.ThrowExceptionIfArgumentNull(nameof(obj));

        public bool Active { get; private set; }

        public void Enable()
        {
            if (Active)
                throw new InvalidOperationException(nameof(Active));

            Active = true;
            _object.SetActive(true);
        }

        public void Disable()
        {
            if (!Active)
                throw new InvalidOperationException(nameof(Disable));

            Active = false;
            _object.SetActive(false);
        }

        public void Destroy()
        {
            Active = false;
            Object.Destroy(_object);
        }
    }
}