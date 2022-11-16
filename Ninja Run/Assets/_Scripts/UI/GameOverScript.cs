using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour         //regelt die Aktionen die passieren sobald man verloren hat
{
    public TextMeshProUGUI text;
    public Animator transitionAnim;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        text.text = score.ToString() + " COINS";
    }

    public void RestartButton()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().name));
    }

    public void MenuButton()
    {
        StartCoroutine(LoadScene("Hauptmenu"));
    }

      IEnumerator LoadScene(string sceneName)
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSecondsRealtime(0.5f);
        
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }
}
