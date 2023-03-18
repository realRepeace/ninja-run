using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour          //regelt alle Aktionen, die verbunden mit dem Pausenmenü geschehen
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    public Animator transitionAnim;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        FindObjectOfType<InputManager>().SwitchActionMap();
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        FindObjectOfType<InputManager>().SwitchActionMap();
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

    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (GameIsPaused == false)
            {
                Pause();
            } else 
            {
                Resume();
            }
        }
    }
}
