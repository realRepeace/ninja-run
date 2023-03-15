using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehaviour : MonoBehaviour
{

    public float shieldDuration;

    private void Start() 
    {
        Destroy(gameObject, shieldDuration);
    }
}
