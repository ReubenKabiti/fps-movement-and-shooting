using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckeredMaterial : MonoBehaviour
{
    int width = 1920;
    int height = 1080;
    public int size = 20;

    Material material;
    Texture2D texture;

    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        texture = new Texture2D(width, height, TextureFormat.RGBA32, true);
        material.SetTexture("_MainTex", texture);

        int nX = width / size;
        int nY = height / size;
        
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float u = (float)x / (width - 1);
                float v = (float)y / (height - 1);
                int s = (int)(u * nX);
                int t = (int)(v * nY);
                float value = 0;
                if ((s + t) % 2 == 0)
                    value = 1;
                texture.SetPixel(x, y, new Color(value, value, value));
            }
        }
        texture.Apply();
    }
}
