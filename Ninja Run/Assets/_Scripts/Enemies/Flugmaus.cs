using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flugmaus : MonoBehaviour
{
    public Rigidbody2D rb;
    private float speed = 0.2f;
    private Vector2 fluggrenze;
    public float flugdistanz = 0.2f;
    private Vector2 startpos;


    void Start()
    {
        startpos = transform.position;
        fluggrenze = new Vector2(transform.position.x, transform.position.y + flugdistanz);
    }

    void FixedUpdate()
    {
        if (transform.position.y > fluggrenze.y)
        {
            Debug.Log("Zu Hoch");
            rb.AddForce(Vector2.down * speed, ForceMode2D.Impulse);
        } else {
            Debug.Log("Zu Tief");
             rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
        }
    }

}
