using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafAttack : MonoBehaviour
{
    public Transform leafPoint;
    public GameObject leaf;
    
    public void SpawnLeaf()
    {
    leafPoint = GameObject.FindGameObjectWithTag("LeafPoint").GetComponent<Transform>();
    Quaternion Rotation = Quaternion.Euler(0f, 0f, 0f);
    Instantiate(leaf, leafPoint.position, Rotation);
    }
}
