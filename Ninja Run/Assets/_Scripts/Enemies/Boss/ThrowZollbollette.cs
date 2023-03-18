using UnityEngine;

public class ThrowZollbollette : MonoBehaviour      //regelt den Wurf der Zollbolletten
{
    public GameObject zollbollette;
    public Transform shotPoint;
    public int attackCount;
    public int maxAttackCount;
    
    public void SpawnZollbollette()
    {
    shotPoint = GameObject.FindGameObjectWithTag("ShotPoint").GetComponent<Transform>();
    Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(10f, 16f));
    Instantiate(zollbollette, shotPoint.position, randomRotation);
    attackCount++;
    if(attackCount>=maxAttackCount)
    {
        gameObject.GetComponent<Animator>().SetTrigger("Shield");
        attackCount = 0;
    }
    }
}
