using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        text.text = score.ToString() + " COINS";
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("Hauptmenu");
        Time.timeScale = 1;
    }
}
