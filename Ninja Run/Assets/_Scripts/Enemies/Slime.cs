using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    private float _distanceToTheGround;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private float jumpHeight = 6f;

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded() == true)
        {
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
