using System;
using Source.Runtime.Tools.Extensions;
using Object = UnityEngine.Object;

namespace Source.Runtime.Views.GameObject
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