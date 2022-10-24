using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pilz : MonoBehaviour
{
    public ParticleSystem mushroomParticle;
    private Animator hitAnimation;

    private void Start() {
        hitAnimation = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Weapon"))
        {
            hitAnimation.SetTrigger("gotHit");
            FindObjectOfType<AudioManager>().Play("pilz sound");
            mushroomParticle.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
         if (other.gameObject.CompareTag("Player"))
        {
            hitAnimation.SetTrigger("gotHit");
            FindObjectOfType<AudioManager>().Play("pilz sound");
            mushroomParticle.Play();
        }
    }
}
