using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour         //regelt die Aktionen die passieren sobald man verloren hat
{
    public TextMeshProUGUI text;
    public Animator transitionAnim;

    public void Setup(int score)        //aktiviert UI und gibt gesammelte Coinzahl aus
    {
        gameObject.SetActive(true);
        text.text = score.ToString() + " COINS";
    }

    public void RestartButton()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().name));
    }

    public void NextButton()
    {
       StartCoroutine(NextScene());
    }

    public void MenuButton()
    {
        StartCoroutine(LoadScene("Hauptmenu"));
    }

      IEnumerator LoadScene(string sceneName)       //definiert den Szenenübergang
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSecondsRealtime(0.5f);
        
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }

      IEnumerator NextScene()       //definiert den Szenenübergang
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSecondsRealtime(0.5f);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }
}
