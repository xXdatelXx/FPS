using UnityEngine;

namespace FPS.Visual
{
    public sealed class PixelEffect : MonoBehaviour
    {
        [SerializeField] private Shader _shader;
        [SerializeField] private Vector2Int _screenSize;
        private Material _material;

        private void Awake()
        {
            _material = new Material(_shader)
            {
                hideFlags = HideFlags.HideAndDontSave
            };
        }

        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            var texture = DownscaleTextures(source);
            UpscaleAndBlit(destination, texture);
        }

        private RenderTexture DownscaleTextures(RenderTexture source)
        {
            var texture = RenderTexture.GetTemporary(_screenSize.x, _screenSize.y, 0, source.format);

            Graphics.Blit(source, texture, _material);
            return texture;
        }

        private void UpscaleAndBlit(RenderTexture destination, RenderTexture texture)
        {
            Graphics.Blit(texture, destination, _material);
            RenderTexture.ReleaseTemporary(texture);
        }
    }
}