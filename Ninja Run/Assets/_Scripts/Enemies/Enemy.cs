using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health, maxHealth = 3f;
    public Rigidbody2D rb;
    public GameObject hitSplash;
    public GameObject hitSplashSmall;
    public HitFlash hitFlash;

    private void Start() {
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount) //Alle zusammenhängenden Aktionen werden abgespielt, wenn der Gegner Schaden erleidet
    {
        health -= damageAmount;
        Instantiate(hitSplashSmall, transform.position, Quaternion.identity);
        hitFlash.Flash();
        FindObjectOfType<AudioManager>().Play("enemydamage");

        if (health <= 0)
        {
            Instantiate(hitSplash, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
