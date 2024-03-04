
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class TestUSharp : UdonSharpBehaviour
{
    private Texture2D texture;

    void Start()
    {
        texture = null;
        Color col = texture.GetPixel(0, 0);
        Debug.Log(col);
    }
}
