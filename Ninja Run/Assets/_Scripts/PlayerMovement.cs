using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public GameObject projectilePrefab;

    private float jumpingPower = 16f;
    private Vector3 Wurfabstand = new Vector3(1.5f, 0, 0);
    private Animator anim;
    private bool isGrounded;


    private void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);

        if (IsGrounded())
        {
            anim.SetBool("isJumping", true);
        } else {
            anim.SetBool("isJumping", false);
        }
    }


    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            anim.SetTrigger("takeOf");
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    public void Wurf(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Instantiate(projectilePrefab, transform.position + Wurfabstand, projectilePrefab.transform.rotation);
        }
    }


    private bool IsGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        return isGrounded;
    }
    
}