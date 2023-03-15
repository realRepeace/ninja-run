using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnShield : MonoBehaviour
{
    public GameObject shield;
    public Transform speakPoint;
    
    public void spawnShield()
    {
    speakPoint = GameObject.FindGameObjectWithTag("SpeakPoint").GetComponent<Transform>();
    Instantiate(shield, speakPoint.position, speakPoint.rotation);
    }
}
