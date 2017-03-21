using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Camera))]
public class RenderCameraToImage : MonoBehaviour
{
    public RawImage targetImage;

    protected RenderTexture renderTexture;
    protected Sprite sprite;

    public void Start ()
    {
        renderTexture = new RenderTexture(Screen.width,Screen.height,0,RenderTextureFormat.ARGB4444);
        GetComponent<Camera>().targetTexture = renderTexture;
        targetImage.texture = renderTexture;
    }
}
