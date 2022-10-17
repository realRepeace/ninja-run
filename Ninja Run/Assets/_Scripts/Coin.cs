using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public ParticleSystem collectCoin;
    public Animator collectAnimation;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            CoinManager.coinAmount += 1;
            FindObjectOfType<AudioManager>().Play("pickupCoin");
            collectAnimation.SetTrigger("collected");
            Instantiate(collectCoin, transform.position, transform.rotation) ;
            //Destroy(gameObject);
        }
    }
}
