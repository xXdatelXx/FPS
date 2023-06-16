using NUnit.Framework;

namespace FPS.Tools.Tests
{
    internal sealed class GameObjectTest
    {
        [Test]
        public void DestroyCorrectly()
        {
            var gameObject = new GameObject(new UnityEngine.GameObject());
            gameObject.Destroy();
            
            Assert.False(gameObject.Active);
        }
        
        [Test]
        public void DisableCorrectly()
        {
            var gameObject = new GameObject(new UnityEngine.GameObject());
            gameObject.Disable();
            
            Assert.False(gameObject.Active);
        }
        
        [Test]
        public void ActivateCorrectly()
        {
            var gameObject = new GameObject(new UnityEngine.GameObject());
            
            gameObject.Disable();
            gameObject.Enable();
            
            Assert.True(gameObject.Active);
        }
    }
}