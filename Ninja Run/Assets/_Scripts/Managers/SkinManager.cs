using UnityEngine;
using UnityEngine.U2D.Animation;

public class SkinManager : MonoBehaviour
{
    public SpriteLibraryAsset[] skins;

    int currentSkin = 0;

    void Start()
    {
        currentSkin = PlayerPrefs.GetInt("currentSkin", 0);     //beim ersten Spielstart ist der Standard-Skin ausgewählt
        ChangeSkin(skins[currentSkin]);
    }

    public void NextSkin()
    {
        currentSkin = (currentSkin + 1) % skins.Length;
        PlayerPrefs.SetInt("currentSkin", currentSkin);
        ChangeSkin(skins[currentSkin]);
    }

    public void PreviousSkin()
    {
        currentSkin = (currentSkin - 1) % skins.Length;
        if (currentSkin < 0) currentSkin = skins.Length - 1;
        PlayerPrefs.SetInt("currentSkin", currentSkin);
        ChangeSkin(skins[currentSkin]);
    }

    public void ChangeSkin(SpriteLibraryAsset skin)
    {
        GetComponent<SpriteLibrary>().spriteLibraryAsset = skin;
    }
}
