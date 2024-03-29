using UnityEngine;

public class Zollbollette : MonoBehaviour       //regelt das Verhalten der Zollbollette
{
    public float speed;
    public float rangeLimit = 10f;
    public float zollbolletteHealth, maxZollbolletteHealth;

    private void Start() 
    {
        Invoke("DestroyObject", rangeLimit);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        zollbolletteHealth++;

        if(zollbolletteHealth >= maxZollbolletteHealth)
        {
            Destroy(gameObject);
        }
    }

    private void Update() 
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void DestroyObject() 
    {
        Destroy(gameObject);
    }
}
