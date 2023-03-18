using UnityEngine;

public class Coin : MonoBehaviour            //regelt das Einsammeln von Münzen
{
    public ParticleSystem collectCoin;
    public Animator collectAnimation;

    private void Start() {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.Find("CoinManager").GetComponent<CoinManager>().currentLevelCoins++;
            CoinManager.coinAmount += 1;
            FindObjectOfType<AudioManager>().Play("pickupCoin");
            collectAnimation.SetTrigger("collected");
            Instantiate(collectCoin, transform.position, transform.rotation) ;
            //Destroy(gameObject);
        }
    }
}
