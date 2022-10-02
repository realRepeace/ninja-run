using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40f;
    public float rotationSpeed = 150f;

    private float rangeLimit = 11f;
    private float damage = 1f;


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

    void OnCollisionEnter2D(Collision2D other) {

        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}