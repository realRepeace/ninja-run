using System.Collections;
using UnityEngine;

public class MapLevelTransition : MonoBehaviour     //Übergangseffekt mit Wolken
{

    public float movePositionX = 70f;
    public float resetPositionX = 700f;
    public GameObject worldSelection;
    public GameObject levelSelection;
    // Start is called before the first frame update


    public void CloudTransition()
    {
        LeanTween.moveLocal(gameObject, new Vector3(movePositionX, 0f, 0f), 0.4f).setDelay(0.2f);   //leantween ist für die Animation von UI Element sehr praktisch
        StartCoroutine(ChangeScene(1.2f));
    }

    private IEnumerator ChangeScene(float duration)
    {
        yield return new WaitForSeconds(duration);
        worldSelection.SetActive(false);
        levelSelection.SetActive(true);
        LeanTween.moveLocal(gameObject, new Vector3(resetPositionX, 0f, 0f), 0.4f);
    }
}
