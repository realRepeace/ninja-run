using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelComplete : MonoBehaviour          //regelt alles was passiert sobald man das Ziel erreicht hat
{
    public GameObject player;
    public GameObject movingBg;
    public GameObject confettiParticle;
    
    public GameOverScript gameOverScript;
    public CoinManager coinManager;
    public PlayerMovement playerMovement;

    public GameObject star2;
    public GameObject star3;

    public GameObject checkbox2;
    public GameObject checkbox3;

    public int thisLevel;
    
    private GameObject[ ] parallaxBg;


    private void Start() {
        parallaxBg = GameObject.FindGameObjectsWithTag("Parallax");
        thisLevel = SceneManager.GetActiveScene().buildIndex;
    }
    

    private void OnTriggerEnter2D(Collider2D other) {   //alle Aktionen die bei Berührung des Ziels passieren
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
            QuestManager();

        }
    }

    void QuestManager()     //Überprüfung ob die Quests geschafft wurden
    {
        Debug.Log("Star1 of Level " + thisLevel);
        if (coinManager.currentLevelCoins > 30)
        {
            star2.SetActive(true);
            checkbox2.SetActive(true);
            Debug.Log("Star2 of Level " + thisLevel);
        }
        if (playerMovement.currentHealth == 3)
        {
            star3.SetActive(true);
            checkbox3.SetActive(true);
            Debug.Log("Star3 of Level " + thisLevel);
        }
    }
}
