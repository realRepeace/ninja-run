using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    public Rigidbody2D rb;
    public float rangeLimit = 10f;
    public float minSpeed;
    public float maxSpeed;

    private float speed;

    private void Start() 
    {
        Random();
        Invoke("DestroyObject", rangeLimit);
        rb.AddForce(Vector2.left * speed, ForceMode2D.Impulse);
    }

    private void DestroyObject() 
    {
        Destroy(gameObject);
    }

    void Random()
    {
        speed = UnityEngine.Random.Range(minSpeed, maxSpeed);
    }
}
