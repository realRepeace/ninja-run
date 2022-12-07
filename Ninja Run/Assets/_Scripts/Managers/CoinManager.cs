using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour        //regelt das Einsammeln von Münzen im UI
{
    [HideInInspector] public TextMeshProUGUI coinText;
    public static int coinAmount;
    public int currentLevelCoins;
    
    void Start()
    {
        coinAmount = SaveManager.instance.currentCoins;
        if (gameObject.GetComponent<TextMeshProUGUI>() != null)
        {
            coinText = GetComponent<TextMeshProUGUI>(); 
        }
    }

    
    void Update()
    {
        if (gameObject.GetComponent<TextMeshProUGUI>() != null)
        {
            coinText.text = coinAmount.ToString();
        }
        SaveManager.instance.currentCoins = coinAmount;
        SaveManager.instance.Save();
    }
}
