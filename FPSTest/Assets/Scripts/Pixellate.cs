using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pixellate : MonoBehaviour
{
    public Material paletteMaterial;
    public Material identityMaterial;

    private RenderTexture _downscaledRenderTexture;

    private void OnEnable()
    {
        var camera = GetComponent<Camera>();
        int height = 240;
        int width = Mathf.RoundToInt(camera.aspect * height);
        _downscaledRenderTexture = new RenderTexture(width, height, 16);
        _downscaledRenderTexture.filterMode = FilterMode.Point;
    }

    private void OnDisable()
    {
        Destroy(_downscaledRenderTexture);
    }
    
    private void OnRenderImage(RenderTexture src, RenderTexture dst)
    {
        
        Graphics.Blit(src, _downscaledRenderTexture, identityMaterial);
        Graphics.Blit(_downscaledRenderTexture, dst, paletteMaterial);
    }
}
