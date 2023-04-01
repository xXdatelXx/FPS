using FPS.Model;
using FPS.Tools;
using UnityEngine;
using GameObject = FPS.Tools.GameObject;

namespace FPS.Factories
{
    public sealed class CharacterHealthFactory : MonoBehaviour, ICharacterHealthFactory
    {
        [SerializeField] private float _healthPoint;
        [SerializeField] private Character _character;
        [SerializeField] private ProText _healthText;

        public void Create()
        {
            var obj = new GameObject(_character.gameObject);
            var healthView = new CharacterHealthView(obj, new TextView(_healthText));
            var health = new Health(_healthPoint, healthView);

            _character.Body.Construct(health, 2);
            _character.Head.Construct(health, 1);
        }
    }
}