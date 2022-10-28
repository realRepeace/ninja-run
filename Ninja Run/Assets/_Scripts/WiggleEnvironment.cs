using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiggleEnvironment : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Wiggle");
            Debug.Log("YALLLLLLLLLLLLA");
        }
    }
}
