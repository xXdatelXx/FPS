using FPS.Model.Rotation;
using FPS.Tools;
using FPS.Views;
using UnityEngine;

namespace FPS.Factories
{
    public sealed class CharacterRotationFactory : MonoBehaviour, ICharacterRotationFactory
    {
        [SerializeField] private Camera _head;
        [SerializeField] private CharacterController _body;
        [SerializeField] private Vector2 _sensitivity;
        [SerializeField] private Range _xEuler;

        public ICharacterRotation Create()
        {
            var bodyRotation = new BodyRotation(new GameObjectWithRotation(_body.transform));
            var headRotation = new HeadRotation(new GameObjectWithRotation(_head.transform), _xEuler);

            return new CharacterRotation(bodyRotation, headRotation, _sensitivity);
        }
    }
}