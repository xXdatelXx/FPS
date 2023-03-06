using FPS.Tools;
using NUnit.Framework;
using UnityEngine;

namespace Source.Runtime.Tools.Tests.PlayMode
{
    public sealed class RayTest
    {
        [Test]
        public void HitCorrectly()
        {
            var spawnPoint = Object.Instantiate(new GameObject()).AddComponent<RaySpawnPoint>();
            var ray = new UnityRay(spawnPoint);
            var border = Object.Instantiate(new GameObject());
            border.transform.position = spawnPoint.Forward;
            border.AddComponent<BoxCollider>().size = Vector3.one;

            ray.Cast(out var hit);
            hit.Is(out Collider hitObject);
            
            Assert.AreEqual(hitObject.name , border.name);
        }
    }
}