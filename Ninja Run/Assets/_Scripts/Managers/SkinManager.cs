using UnityEngine;
using UnityEngine.UI;

public class SkinManager : MonoBehaviour
{
    public Sprite[] skins;
    public Image skinPreviewUI;
    
    int currentSkin = 0;

    public static Sprite selectedSkin;
    // Start is called before the first frame update
    void Start()
    {
        currentSkin = PlayerPrefs.GetInt("currentSkin", 0);     //beim ersten Spielstart ist der Standard-Skin ausgewählt
        skinPreviewUI.sprite = skins[currentSkin];  
        Debug.Log(currentSkin);
    }

    public void NextSkin()
    {
        currentSkin = (currentSkin + 1) % skins.Length;
        skinPreviewUI.sprite = skins[currentSkin];
        PlayerPrefs.SetInt("currentSkin", currentSkin);
        selectedSkin = skins[currentSkin];
    }

    public void PreviousSkin()
    {
        currentSkin = (currentSkin - 1) % skins.Length;
        if (currentSkin < 0) currentSkin = skins.Length - 1;
        skinPreviewUI.sprite = skins[currentSkin];
        PlayerPrefs.SetInt("currentSkin", currentSkin);
        selectedSkin = skins[currentSkin];
    }
}
