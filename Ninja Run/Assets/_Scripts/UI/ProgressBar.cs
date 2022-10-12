using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public MoveLeft moveLeft;
    public Image fillImage;
    private Slider slider;

    private float fillValue = 0;


    void Start()
    {
        slider = GetComponent<Slider>();
    }


    void Update()   //Lebensleiste wird verändert je nach Schaden
    {
        fillValue = fillValue * 1.2f;
        slider.value = fillValue;
    }
}
