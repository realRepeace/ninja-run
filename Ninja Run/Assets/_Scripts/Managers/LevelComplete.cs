using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour          //regelt alles was passiert sobald man das Ziel erreicht hat
{
    public GameObject player;
    public GameObject movingBg;
    public GameObject confettiParticle;
    public GameOverScript gameOverScript;
    
    private GameObject[ ] parallaxBg;

    private void Start() {
        parallaxBg = GameObject.FindGameObjectsWithTag("Parallax");
    }
    

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<ConstantForce2D>().enabled = true;
            movingBg.GetComponent<MoveLeft>().enabled = false;
            Instantiate(confettiParticle, transform.position + new Vector3(0, 5, 0), transform.rotation);
            foreach (GameObject gameObject in parallaxBg)
            {
                gameObject.GetComponent<Parallax>().enabled = false;
            }
            gameOverScript.Setup(CoinManager.coinAmount);
        }
    }
}
