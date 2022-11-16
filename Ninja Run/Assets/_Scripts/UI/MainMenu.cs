using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour       //regelt die Orientierung im Menü
{
    public Animator transitionAnim;

    public void GoToScene(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }

    public void QuitApp()
    {
        Application.Quit();
    }

    IEnumerator LoadScene(string sceneName)
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }
}
