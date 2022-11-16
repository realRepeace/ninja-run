using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour        //regelt das Einsammeln von Münzen im UI
{
    [HideInInspector] public TextMeshProUGUI text;
    public static int coinAmount;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>(); 
    }

    
    void Update()
    {
        text.text = coinAmount.ToString();
    }
}
