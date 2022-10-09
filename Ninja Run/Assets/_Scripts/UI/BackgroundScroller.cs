using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroller : MonoBehaviour
{
    public RawImage img;
    public float x, y;
    void Update()   //Bewegt den Hintergrund mit geringer Geschwindigkeit
    {
        img.uvRect = new Rect(img.uvRect.position + new Vector2(x,y) * Time.deltaTime, img.uvRect.size);
    }
}
