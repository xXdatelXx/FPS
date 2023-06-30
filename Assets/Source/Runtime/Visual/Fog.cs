using UnityEngine;

namespace FPS.Visual
{
    // I stole it and I don't know how it works
    [RequireComponent(typeof(Camera))]
    public sealed class Fog : MonoBehaviour
    {
        [SerializeField] private Shader _shader;
        [SerializeField] private Color _color;
        [SerializeField, Range(0.0f, 1.0f)] private float _density;
        [SerializeField, Range(0.0f, 100.0f)] private float _fogOffset;
        private Material _material;

        private void Start()
        {
            _material = new Material(_shader)
            {
                hideFlags = HideFlags.HideAndDontSave
            };

            var camera = GetComponent<Camera>();
            camera.depthTextureMode |= DepthTextureMode.Depth;
        }

        [ImageEffectOpaque]
        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            _material.SetVector("_FogColor", _color);
            _material.SetFloat("_FogDensity", _density);
            _material.SetFloat("_FogOffset", _fogOffset);
            Graphics.Blit(source, destination, _material);
        }
    }
}