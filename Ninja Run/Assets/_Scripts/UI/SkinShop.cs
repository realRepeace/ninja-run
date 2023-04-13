using UnityEngine;
using UnityEngine.UI;

public class SkinShop : MonoBehaviour
{
    GameObject itemTemplate;
    GameObject g;
    [SerializeField] Transform shopScrollView;

    void Start() {
        itemTemplate = shopScrollView.GetChild(0).gameObject;
        for (int i = 0; i < 10; i++)
        {
            g = Instantiate(itemTemplate, shopScrollView);
        }
        Destroy(itemTemplate);
    }

}
