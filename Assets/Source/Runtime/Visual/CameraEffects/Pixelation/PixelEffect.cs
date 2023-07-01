using UnityEngine;

namespace FPS.Visual
{
    public sealed class PixelEffect : MonoBehaviour
    {
        [SerializeField] private Shader _shader;
        [SerializeField, Range(0, 8)] private int _force = 0;
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
            var textures = DownscaleTextures(source, _force);
            UpscaleAndBlit(source, destination, textures);
        }

        private RenderTexture[] DownscaleTextures(RenderTexture source, int force)
        {
            var width = source.width;
            var height = source.height;
            var textures = new RenderTexture[force];
            var currentSource = source;

            for (int i = 0; i < force; ++i)
            {
                width /= 2;
                height /= 2;

                if (height < 2)
                    break;

                textures[i] = RenderTexture.GetTemporary(width, height, 0, source.format);

                Graphics.Blit(currentSource, textures[i], _material);
                currentSource = textures[i];
            }

            return textures;
        }

        private void UpscaleAndBlit(RenderTexture source, RenderTexture destination, RenderTexture[] textures)
        {
            Graphics.Blit(textures[^1], destination, _material);

            foreach (var texture in textures)
                RenderTexture.ReleaseTemporary(texture);
        }
    }
}