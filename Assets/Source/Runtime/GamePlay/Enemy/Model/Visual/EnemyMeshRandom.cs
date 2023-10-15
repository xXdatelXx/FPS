using System.Collections.Generic;
using FPS.Toolkit;
using Sirenix.OdinInspector;
using UnityEngine;

namespace FPS.GamePlay
{
    public sealed class EnemyMeshRandom : SerializedMonoBehaviour
    {
        [SerializeField] private MeshFilter _body;
        [SerializeField] private MeshFilter _head;
        [SerializeField] private MeshFilter _leftArm;
        [SerializeField] private MeshFilter _rightArm;
        [Header("body, head, arm")]
        [SerializeField] private List<(Mesh body, Mesh head, Mesh arm)> _organSets;

        private void Awake()
        {
            var organMeshSet = _organSets.RandomElement();

            _body.mesh = organMeshSet.body;
            _head.mesh = organMeshSet.head;
            _leftArm.mesh = organMeshSet.arm;
            _rightArm.mesh = organMeshSet.arm;
        }
    }
}