using UnityEngine;

public class LeafAttack : MonoBehaviour
{
    public GameObject leaf;
    private Vector3 leafPoint = new Vector3(-1.36f, 1.15f, 0);
    
    public void SpawnLeaf()
    {
    Quaternion Rotation = Quaternion.Euler(0f, 0f, 0f);
    Instantiate(leaf, gameObject.transform.position + leafPoint, Rotation);
    }
}
