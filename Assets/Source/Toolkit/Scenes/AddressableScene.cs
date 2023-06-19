using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace FPS.Toolkit
{
    [CreateAssetMenu(menuName = nameof(AddressableScene), fileName = nameof(Scene))]
    public sealed class AddressableScene : ScriptableObject, IAsyncScene
    {
        [SerializeField] private AssetReference _sceneAsset;

        public AddressableScene(AssetReference sceneAsset) =>
            _sceneAsset = sceneAsset.ThrowExceptionIfArgumentNull(nameof(sceneAsset));

        public async UniTask Load() =>
            await _sceneAsset.LoadSceneAsync().ToUniTask();
    }
}