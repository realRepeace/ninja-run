using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
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
        PauseMenu.GameIsPaused = false;
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().name));
    }

    public void MenuButton()
    {
        PauseMenu.GameIsPaused = false;
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
