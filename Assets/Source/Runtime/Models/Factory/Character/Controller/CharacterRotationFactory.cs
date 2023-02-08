using FPS.Model.Rotation;
using Sirenix.OdinInspector;
using Source.Runtime.Tools.Math;
using UnityEngine;

namespace Source.Runtime.CompositeRoot
{
    public sealed class CharacterRotationFactory : MonoBehaviour, ICharacterRotationFactory
    {
        [SerializeField] private Camera _head;
        [SerializeField] private CharacterController _body;
        [SerializeField] private Vector2 _sensitivity;
        [SerializeField] private Range _xEuler;

        public ICharacterRotation Create()
        {
            var bodyRotation = new BodyRotation(_body);
            var headRotation = new HeadRotation(_head, _xEuler);

            return new CharacterRotation(bodyRotation, headRotation, _sensitivity);
        }
    }
}