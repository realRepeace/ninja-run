using UnityEngine;

public class ShieldBehaviour : MonoBehaviour    //regelt die Schilddauer
{

    public float shieldDuration;

    private void Start() 
    {
        Destroy(gameObject, shieldDuration);
    }
}
