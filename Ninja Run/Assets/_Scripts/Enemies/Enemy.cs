using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health, maxHealth = 3f;
    public Rigidbody2D rb;

    private void Start() {
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        rb.AddForce(Vector2.right * 4f, ForceMode2D.Impulse);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
