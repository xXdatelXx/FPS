using System;
using FPS.Model;
using FPS.Tools;
using UnityEngine;
using GameObject = UnityEngine.GameObject;

namespace FPS.Factories
{
    public sealed class CharacterHealthFactory : MonoBehaviour, ICharacterHealthFactory
    {
        [SerializeField] private float _healthPoint;
        [SerializeField] private GameObject _character;
        [SerializeField] private CharacterOrgan _head;
        [SerializeField] private CharacterOrgan _body;
        [SerializeField] private ProText _healthText;

        private void OnValidate()
        {
            var organs = _character.GetComponentsInChildren<CharacterOrgan>();

            void Validate(ref CharacterOrgan organ, string name)
            {
                if (!organs.Has(organ))
                {
                    organ = null;
                    throw new ArgumentNullException("name is not on character");
                }
            }
            
            Validate(ref _head, nameof(_head));
            Validate(ref _body, nameof(_body));
        }

        public void Create()
        {
            var obj = new FPS.Tools.GameObject(_character);
            var healthView = new CharacterHealthView(obj, new TextView(_healthText));
            var health = new Health(_healthPoint, healthView);

            _head.Construct(health, 2);
            _body.Construct(health, 1);
        }
    }
}