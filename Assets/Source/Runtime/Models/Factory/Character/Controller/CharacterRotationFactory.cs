using Source.Runtime.Models.Player.Rotation;
using Source.Runtime.Tools.Math;
using Source.Runtime.Views.GameObject;
using UnityEngine;

namespace Source.Runtime.Models.Factory.Character.Controller
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