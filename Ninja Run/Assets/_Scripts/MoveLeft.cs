using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10f;

    void LateUpdate()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
