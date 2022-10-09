using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillStatusBar : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Image fillImage;
    private Slider slider;


    void Start()
    {
        slider = GetComponent<Slider>();
    }


    void Update()   //Lebensleiste wird verändert je nach Schaden
    {
        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }
        if (slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }

        float fillValue = playerMovement.currentHealth / playerMovement.maxHealth;
        slider.value = fillValue;
    }
}
