using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class BuySkin : MonoBehaviour        //regelt den Kauf eines Skins
{
    public SkinManager skinManager;
    public int skinIndex = 0;

    private Button button;
    private TextMeshProUGUI price;
    private int priceInt;

    private void Start() {
        price = GetComponentInChildren<TextMeshProUGUI>();
        button = GetComponent<Button>();
        int.TryParse(price.text, out priceInt);
        ifAlreadyPurchased();
    }

    public void Buy()
    {
        skinManager.UnlockSkin(skinIndex);
        ifAlreadyPurchased();
        CoinManager.coinAmount -= priceInt;
    }

    void FixedUpdate()
    {
        
        hasEnoughMoney(priceInt);
    }

    void hasEnoughMoney(int price)
    {
        if(CoinManager.coinAmount <= price  || skinManager.skinUnlockedCheck[skinIndex])
        {
            button.interactable = false;
            gameObject.transform.GetComponent<Shadow>().enabled = false;
        } 
        else {
            button.interactable = true;
            gameObject.transform.GetComponent<Shadow>().enabled = true;
        }
    }

    void ifAlreadyPurchased()
    {
        if (skinManager.skinUnlockedCheck[skinIndex])
        {
                price.text = "Purchased";
                gameObject.transform.GetChild(2).gameObject.SetActive(true);
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
                gameObject.transform.GetComponent<Shadow>().enabled = false;
        }
    }
}
