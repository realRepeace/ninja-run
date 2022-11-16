using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour           //bewegt das Objekt konstant nach links
{
    public float speed;
    public float startpos;

    private void Start() {
        startpos = transform.position.x;
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
