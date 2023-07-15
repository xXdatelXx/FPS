using System;
using FPS.GamePlay;
using FPS.Toolkit;
using FPS.Toolkit.GameLoop;
using UnityEngine;
using GameObject = UnityEngine.GameObject;

namespace FPS.Factories
{
    public sealed class CharacterHealthFactory : MonoBehaviour, IFactory<IHealth>
    {
        [SerializeField] private float _healthPoint;
        [SerializeField] private float _heal;
        [SerializeField] private GameObject _character;
        [SerializeField] private Animator _animator;
        [SerializeField] private string _damageAnimation;
        [SerializeField] private CharacterOrgan _head;
        [SerializeField] private CharacterOrgan _body;
        [SerializeField] private ProText _healthText;
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
            var obj = new Toolkit.GameObject(_character);
            var damageAnimation = new UnityAnimation(_animator, _damageAnimation);
            var healthView = new CharacterHealthView(obj, _healthText, damageAnimation);
            var health = new Health(_healthPoint, healthView);

            _healLoopObject = new AutoHeal(health, _heal);
            _head.Construct(health, 2);
            _body.Construct(health, 1);

            return health;
        }

        private void Update() =>
            _healLoopObject.Tick(Time.deltaTime);
    }
}