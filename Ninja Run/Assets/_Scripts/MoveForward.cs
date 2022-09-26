using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40f;
    public float rotationSpeed = 150f;

    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
        
        transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime, Space.Self); 
        Destroy();
    }

    private void Destroy() 
    {
        if (transform.position.x >= 22)
        {
            Destroy(gameObject);
        }
    }
}