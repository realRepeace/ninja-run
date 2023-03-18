using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour          //regelt alles was passiert sobald man das Ziel erreicht hat
{
    public GameObject player;
    public GameObject movingBg;
    public GameObject confettiParticle;
    
    public GameOverScript gameOverScript;
    public CoinManager coinManager;

    public int thisLevel;
    
    private GameObject[ ] parallaxBg;


    private void Start() {
        parallaxBg = GameObject.FindGameObjectsWithTag("Parallax");
        thisLevel = SceneManager.GetActiveScene().buildIndex;
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
            gameOverScript.Setup(coinManager.currentLevelCoins);        //die UI für "Level geschafft" wird aufgerufen

            if(thisLevel > PlayerPrefs.GetInt("currentLevel"))
            {
                PlayerPrefs.SetInt("currentLevel", thisLevel);
                Debug.Log(thisLevel);
            }
        }
    }
}
