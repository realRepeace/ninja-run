using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] lvlButtons;
    // Start is called before the first frame update
    void Start()
    {
        int currentLevel = PlayerPrefs.GetInt("currentLevel", 1);

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i > currentLevel)
            {
                lvlButtons[i].interactable = false;
                GameObject buttonLock = lvlButtons[i].transform.GetChild(1).gameObject; // Zugriff auf das erste Child-Objekt des ersten Buttons im Array
                GameObject buttonText = lvlButtons[i].transform.GetChild(0).gameObject;
                buttonLock.SetActive(true);
                buttonText.SetActive(false);
            }
        }
    }
}
