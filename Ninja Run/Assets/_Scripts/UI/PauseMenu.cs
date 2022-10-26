using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    public Animator transitionAnim;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void RestartButton()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().name));
    }

    public void Home()
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
