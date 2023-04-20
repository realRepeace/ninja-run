using UnityEngine;

public class CheatsManager : MonoBehaviour      //regelt Cheats, die das Testen von Elementen erleichtern
{
    public GameObject moveLeft;
    public GameObject teleportPoint;

    private int testzahl = 5;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (CoinManager.coinAmount > 0)
            {
                CoinManager.coinAmount -= 100;
                if (CoinManager.coinAmount < 0)
                {
                    CoinManager.coinAmount = 0;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            CoinManager.coinAmount = 0;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            CoinManager.coinAmount += 100;
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            moveLeft.transform.position = new Vector2(-teleportPoint.transform.position.x, moveLeft.transform.position.y);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.SetInt("currentLevel", testzahl);
            Debug.Log(testzahl);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
