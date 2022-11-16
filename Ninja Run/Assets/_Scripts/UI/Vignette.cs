using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vignette : MonoBehaviour           //ist zuständig für die Animation beim Wechseln der Szene
{
    public PlayerMovement playerMovement;
    public Animator fadeAnim;
    private float currentHealthPlusOne;

    private void Start() {
        currentHealthPlusOne = playerMovement.maxHealth;
    }

    private void Update() {
        if (currentHealthPlusOne != playerMovement.currentHealth)
        {
            fadeAnim.SetTrigger("damageTaken");
            currentHealthPlusOne = playerMovement.currentHealth;
        }
    }

}
