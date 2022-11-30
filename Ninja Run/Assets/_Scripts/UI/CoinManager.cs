using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour        //regelt das Einsammeln von Münzen im UI
{
    [HideInInspector] public TextMeshProUGUI coinText;
    public static int coinAmount;

    void Start()
    {
        coinAmount = SaveManager.instance.currentCoins;
        coinText = GetComponent<TextMeshProUGUI>(); 
    }

    
    void Update()
    {
        coinText.text = coinAmount.ToString();
        SaveManager.instance.currentCoins = coinAmount;
        SaveManager.instance.Save();
    }
}
