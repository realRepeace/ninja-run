using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wurfstern : MonoBehaviour
{
    public float speed = 40f;
    public float rotationSpeed = 150f;

    private float rangeLimit = 11f;
    private float damage = 0.5f;
    private float horizontalKnockback = 3f;


    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
        
        transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime, Space.Self); 
        OutOfSight();
    }

    private void OutOfSight() 
    {
        if (transform.position.x >= rangeLimit)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(damage);
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * horizontalKnockback, ForceMode2D.Impulse);
        }
        Destroy(gameObject);
    } 
}