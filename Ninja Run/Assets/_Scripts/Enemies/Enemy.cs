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

    public AudioClip damageSound;

    private AudioSource enemyAudio;

    private void Start() {
        health = maxHealth;
        enemyAudio = GetComponent<AudioSource>();
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        Instantiate(hitSplashSmall, transform.position, Quaternion.identity);
        hitFlash.Flash();
        FindObjectOfType<AudioManager>().Play("enemydamage");
        rb.AddForce(Vector2.right * 4f, ForceMode2D.Impulse);

        if (health <= 0)
        {
            Instantiate(hitSplash, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
