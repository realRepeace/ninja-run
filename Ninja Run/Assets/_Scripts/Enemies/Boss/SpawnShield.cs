using UnityEngine;

public class SpawnShield : MonoBehaviour        //regelt die Erstellung des Schildes
{
    public GameObject shield;
    public Transform speakPoint;
    
    public void spawnShield()
    {
    speakPoint = GameObject.FindGameObjectWithTag("SpeakPoint").GetComponent<Transform>();
    Instantiate(shield, speakPoint.position, speakPoint.rotation);
    }
}
