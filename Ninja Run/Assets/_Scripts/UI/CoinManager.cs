using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
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
