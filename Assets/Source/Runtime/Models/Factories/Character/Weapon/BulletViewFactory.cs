using System.Linq;
using FPS.Model;
using FPS.Tools;
using FPS.Views;
using UnityEngine;
using GameObject = FPS.Views.GameObject;

namespace FPS.Factories
{
    public sealed class BulletViewFactory : MonoBehaviour, IFactory<IBulletView>
    {
        [SerializeField] private ParticleSystem _startBulletParticle;
        [SerializeField] private ParticleSystem _hitBulletParticle;
        [SerializeField] private Sprite[] _hitSprites;
        [SerializeField] private SpriteRenderer _hitSpriteRenderer;

        public IBulletView Create() => 
            new BulletView(new BulletParticle(_startBulletParticle), CreateHitView(), new BulletRay());

        private IBulletHitView CreateHitView()
        {
            var unitySpites = _hitSprites.Select(i => new UnitySpite(_hitSpriteRenderer, i)).ToArray();
            var hitSprite = new BulletHitSprites(unitySpites);
            var spiteObject = new MovementGameObject(new GameObject(_hitSpriteRenderer.gameObject), new GameObjectWithMovement(_hitSpriteRenderer.transform));
            
            return new BulletHitView(new BulletParticle(_hitBulletParticle), hitSprite, spiteObject);
        }
    }
}