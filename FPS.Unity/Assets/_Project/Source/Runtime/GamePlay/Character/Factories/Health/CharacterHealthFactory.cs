using System;
using FPS.Data;
using FPS.GamePlay;
using FPS.Toolkit;
using FPS.Toolkit.GameLoop;
using UnityEngine;
using GameObject = UnityEngine.GameObject;

namespace FPS.Factories
{
    public sealed class CharacterHealthFactory : MonoBehaviour, IFactory<IHealth>
    {
        [SerializeField] private CharacterConfig _config;
        [SerializeField] private GameObject _character;
        [SerializeField] private CharacterOrgan _head;
        [SerializeField] private CharacterOrgan _body;
        [SerializeField] private CharacterHealthViewFactory _viewFactory;
        private IGameLoopObject _healLoopObject;

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

        public IHealth Create()
        {
            var health = new Health(_config.Health, _viewFactory.Create());

            _healLoopObject = new AutoHeal(health, _config.HealPerTick);
            _head.Construct(health, 2);
            _body.Construct(health, 1);

            return health;
        }

        private void Update() =>
            _healLoopObject.Tick(Time.deltaTime);
    }
}