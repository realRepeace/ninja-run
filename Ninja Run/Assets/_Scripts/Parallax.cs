using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos;
    public GameObject ground;
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        startpos= transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = (ground.transform.position.x * (1 - parallaxEffect));
        float tempo = ground.transform.position.x * parallaxEffect;

        transform.position = new Vector3(startpos + tempo, transform.position.y, transform.position.z);
    }
}
