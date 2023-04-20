using UnityEngine;
using UnityEngine.U2D.Animation;

public class SkinManager : MonoBehaviour        //regelt das Ändern der Skins im Menü
{
    public SpriteLibraryAsset[] skins;
    [HideInInspector] public bool[] skinUnlockedCheck;

    private int currentSkin = 0;

    private void Start()          //beim ersten Spielstart ist der Standard-Skin ausgewählt
    {
        currentSkin = PlayerPrefs.GetInt("currentSkin", 0);
        ChangeSkin(skins[currentSkin]);

        skinUnlockedCheck = new bool[skins.Length];
        for (int i = 0; i < skins.Length; i++)
        {
            skinUnlockedCheck[i] = PlayerPrefs.GetInt("skin" + i.ToString(), 0) == 1;
        }
        skinUnlockedCheck[0] = true;
    }

    public void NextSkin()          //es wird überprüft ob der nächste Skin freigeschaltet wurde und dann zum nächst verfügbaren gewechselt
    {
        int nextSkinIndex = (currentSkin + 1) % skins.Length;
        while (!IsSkinUnlocked(nextSkinIndex))
        {
            nextSkinIndex = (nextSkinIndex + 1) % skins.Length;
        }
        currentSkin = nextSkinIndex;
        SaveCurrentSkin();
        ChangeSkin(skins[currentSkin]);
    }

    public void PreviousSkin()      //es wird überprüft ob der vorherige Skin freigeschaltet wurde und dann zum vorherigen verfügbaren gewechselt
    {
        int prevSkinIndex = (currentSkin - 1 + skins.Length) % skins.Length;
        while (!IsSkinUnlocked(prevSkinIndex))
        {
            prevSkinIndex = (prevSkinIndex - 1 + skins.Length) % skins.Length;
        }
        currentSkin = prevSkinIndex;
        SaveCurrentSkin();
        ChangeSkin(skins[currentSkin]);
    }

    public void ChangeSkin(SpriteLibraryAsset skin)
    {
        GetComponent<SpriteLibrary>().spriteLibraryAsset = skin;
    }

    public bool IsSkinUnlocked(int index)
    {
        return skinUnlockedCheck[index];
    }

    public void UnlockSkin(int index)
    {
        skinUnlockedCheck[index] = true;
        PlayerPrefs.SetInt("skin" + index.ToString(), 1);
    }

    private void SaveCurrentSkin()
    {
        PlayerPrefs.SetInt("currentSkin", currentSkin);
        PlayerPrefs.Save();
    }
}