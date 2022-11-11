using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    public GameObject player;
    public GameObject movingBg;
    GameObject[ ] parallaxBg = GameObject.FindGameObjectsWithTag("Parallax");

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            movingBg.GetComponent<MoveLeft>().enabled = false;
            //GetComponent<Parallax>().enabled = false;
        }
    }
}
