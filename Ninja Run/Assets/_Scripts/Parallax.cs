using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed = 4f;
    public float parallaxEffect;

     private Vector2 startPos;
     private float length;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed * parallaxEffect);

        if (transform.position.x < startPos.x - length)
        {
            transform.position = startPos;
        }
    }
}
