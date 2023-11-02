using FPS.GamePlay;
using FPS.Input;
using FPS.Toolkit;
using UnityEngine;

namespace FPS.Factories
{
    public sealed class CharacterRotationFactory : MonoBehaviour, ICharacterRotationFactory
    {
        [SerializeField] private CharacterOrgan _head;
        [SerializeField] private CharacterController _body;
        [SerializeField] private Range _xEuler;

        public ICharacterRotation Create()
        {
            var bodyRotation = new BodyRotation(new Rotation(_body.transform));
            var headRotation = new HeadRotation(new Rotation(_head.transform), _xEuler);

            return new CharacterRotation(bodyRotation, headRotation, new MouseSensitivity());
        }
    }
}