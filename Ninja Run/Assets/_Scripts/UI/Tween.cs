using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tween : MonoBehaviour
{

    public void Open()
    {
        LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), 0.8f).setDelay(0.1f).setEase(LeanTweenType.easeOutExpo);
    }

    public void Close()
    {
        LeanTween.scale(gameObject, new Vector3(0f, 0f, 0f), 0.4f).setEase(LeanTweenType.easeInQuart);
    }
}
