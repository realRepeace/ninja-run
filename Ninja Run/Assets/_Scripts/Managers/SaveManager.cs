using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour        //regelt das speichern des aktuellen Spielstandes
{
    public static SaveManager instance { get; private set; }

    public int currentSkin;
    public int currentCoins;

    private void Awake()        //am Anfang einer Szene wird überprüft, ob der "Speichermanager" bereits aktiv ist
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        } else {
            instance = this;
        }
        DontDestroyOnLoad(gameObject);
        Load();
    }

    public void Load()          //Nach dem Starten des Spiels wird der Spielstand geladen
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData_Storage data = (PlayerData_Storage)bf.Deserialize(file);

            currentSkin = data.currentSkin;
            currentCoins = data.currentCoins;

            file.Close();
        }
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData_Storage data = new PlayerData_Storage();

        data.currentSkin = currentSkin;
        data.currentCoins = currentCoins;

        bf.Serialize(file, data);
        file.Close();
    }
}

[Serializable]

class PlayerData_Storage
{
    public int currentSkin;
    public int currentCoins;
}
