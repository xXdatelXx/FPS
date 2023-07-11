using System;
using System.Collections.Generic;
using System.Linq;
using FPS.Toolkit;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class EnemyMeshRandom : MonoBehaviour
    {
        [SerializeField] private List<MeshFilter> _organs;
        [SerializeField] private List<List<Mesh>> _organsMeshes;

        private void OnValidate()
        {
            if (_organsMeshes.Any(organs => organs.Count != _organs.Count))
                throw new ArgumentOutOfRangeException(nameof(_organsMeshes));
        }

        private void Awake()
        {
            var meshes = _organsMeshes.RandomElement();
            for (var i = 0; i < meshes.Count; i++) 
                _organs[i].mesh = meshes[i];
        }
    }
}