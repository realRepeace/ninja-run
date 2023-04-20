using UnityEngine;

public class DontDestroyOnSceneChange : MonoBehaviour
{
    public static DontDestroyOnSceneChange instance { get; private set; }           //Zerstört das Objekt nicht beim Szenenwechsel

    private void Awake() {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        } else {
            instance = this;
        }
        DontDestroyOnLoad(transform.gameObject);
    }
}
