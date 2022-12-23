using UnityEngine;
using System.Collections;
using UnityEngine.UI; // required when using UI elements in scripts
using UnityEngine.EventSystems;// Required when using Event data.

public class ButtonSelectionScript : MonoBehaviour// required interface when using the OnSelect method.
{
    public Button button;

    //Do this OnClick.
    public void SelectDefaultButton()
    {
        //Makes the Input Field the selected UI Element.
        button.Select();
    }
}