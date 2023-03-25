using FPS.Model;
using FPS.Tools;
using UnityEngine;
using GameObject = FPS.Tools.GameObject;

namespace FPS.Factories
{
    public sealed class CharacterHealthFactory : MonoBehaviour, ICharacterHealthFactory
    {
        [SerializeField] private CharacterOrgan _head;
        [SerializeField] private CharacterOrgan _body;
        [SerializeField] private float _healthPoint;
        [SerializeField] private Character _character;
        [SerializeField] private ProText _healthText;

        public void Create()
        {
            var character = new GameObject(_character.gameObject);
            var healthView = new CharacterHealthView(new TextView(_healthText), character);
            var health = new Health(_healthPoint, healthView);

            _head.Construct(health, 2);
            _body.Construct(health, 1);
        }
    }
}