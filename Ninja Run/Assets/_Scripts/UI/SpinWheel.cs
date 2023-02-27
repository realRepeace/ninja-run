using UnityEngine;
using EasyUI.PickerWheelUI;
using UnityEngine.UI;
using TMPro;

public class SpinWheel : MonoBehaviour      //regelt die Funktion des Glücksrades
{
    [SerializeField] private Button uiSpinButton;
    [SerializeField] private TextMeshProUGUI uiSpinButtonText;

    [SerializeField] private PickerWheel pickerWheel;

    [SerializeField] private GameObject rewardPopup;
    [SerializeField] private TextMeshProUGUI rewardPopupText;

    private int spinPrice = 100;

    private void Start() {
        uiSpinButton.onClick.AddListener (() => {       //während dem Drehen wird der Button deaktiviert
            uiSpinButton.interactable = false;
            CoinManager.coinAmount -= spinPrice;
            pickerWheel.OnSpinStart(() => {
                Debug.Log("Spin started");
            });

            pickerWheel.OnSpinEnd(wheelPiece => {
                Debug.Log("Spin Ended: " + wheelPiece.Label + ", Amount: " + wheelPiece.Amount);
                CoinManager.coinAmount += wheelPiece.Amount;
                showPopup(wheelPiece.Amount);
                uiSpinButton.interactable = true;
                 
            });
            
            pickerWheel.Spin();
        });
    }

    private void Update() {     //überprüft ob Spieler genügend Geld hat um zu drehen
        if (CoinManager.coinAmount < spinPrice || pickerWheel.IsSpinning)
        {
            uiSpinButton.interactable = false;
        } else {
            uiSpinButton.interactable = true;
        }
    }

    private void showPopup(int wheelPiece)
    {
        LeanTween.scale(rewardPopup, new Vector3(1f, 1f, 1f), 0.8f).setDelay(0.1f).setEase(LeanTweenType.easeOutExpo);
        rewardPopupText.text = wheelPiece.ToString();
    }
}
