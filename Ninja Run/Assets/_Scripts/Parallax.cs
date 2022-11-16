using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour       //ist zuständig für den Effekt bei dem der Hintergrund sich unterschiedlich schnell bewegt
{
    public float speed = 4f;
    public float parallaxEffect;

     private Vector2 startPos;
     private float length;
    
    void Start()
    {
        startPos = transform.position;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    
    void Update() //Wenn der Hintergrund am Ende angekommen ist, wird er wiederholt
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed * parallaxEffect);

        if (transform.position.x < startPos.x - length)
        {
            transform.position = startPos;
        }
    }
}
