using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatsManager : MonoBehaviour      //regelt Cheats, die das Testen von Elementen erleichtern
{
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
    }
}
