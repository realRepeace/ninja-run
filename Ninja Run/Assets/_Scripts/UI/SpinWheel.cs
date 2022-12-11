using UnityEngine;
using EasyUI.PickerWheelUI;
using UnityEngine.UI;
using TMPro;

public class SpinWheel : MonoBehaviour
{
    [SerializeField] private Button uiSpinButton;
    [SerializeField] private TextMeshProUGUI uiSpinButtonText;

    [SerializeField] private PickerWheel pickerWheel;

    private int spinPrice = 100;

    private void Start() {
        uiSpinButton.onClick.AddListener (() => {
            uiSpinButton.interactable = false;
            CoinManager.coinAmount -= spinPrice;
            pickerWheel.OnSpinStart(() => {
                Debug.Log("Spin started");
            });

            pickerWheel.OnSpinEnd(wheelPiece => {
                Debug.Log("Spin Ended: " + wheelPiece.Label + ", Amount: " + wheelPiece.Amount);
                CoinManager.coinAmount += wheelPiece.Amount;
                uiSpinButton.interactable = true;
            });
            
            pickerWheel.Spin();
        });
    }

    private void Update() {
        if (CoinManager.coinAmount < spinPrice || pickerWheel.IsSpinning)
        {
            uiSpinButton.interactable = false;
        } else {
            uiSpinButton.interactable = true;
        }
    }
}
