using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    private float _distanceToTheGround;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private int jumpHeight = 0;
    

    
    private void Start() {
        Random();
    }

    void FixedUpdate()
    {
        if (IsGrounded() == true)
        {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            Random();
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void Random()
    {
        jumpHeight = UnityEngine.Random.Range(10, 30);
    }
}
