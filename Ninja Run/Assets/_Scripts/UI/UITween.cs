using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITween : MonoBehaviour        //LeanTween Animation für Popups
{
    public GameObject ObjectToOpen;
    public GameObject ObjectToClose;
    // Start is called before the first frame update
    public void Open()
    {
        ObjectToOpen.gameObject.SetActive(true);
        ObjectToOpen.transform.LeanScale(Vector2.one, 2f);
    }

    // Update is called once per frame
    public void Close()
    {
        ObjectToClose.LeanScale(Vector2.zero, 1f).setEaseInBack();
    }
}
