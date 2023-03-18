using UnityEngine;

public class ThrowBottle : MonoBehaviour        //regelt den Wurf der Flasche des Bosses
{
    public Transform shotPoint;
    public GameObject bottle;
    
    public void SpawnBottle()
    {
        shotPoint = GameObject.FindGameObjectWithTag("ShotPoint").GetComponent<Transform>();
        Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(10f, 126f));
        Instantiate(bottle, shotPoint.position, randomRotation);
    }
}
