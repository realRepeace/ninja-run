using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public ParticleSystem dustParticle;
    public AudioClip jumpSound;
    public AudioClip throwSound;
    public AudioClip pickupCoin;

    public GameObject projectilePrefab;

    private float jumpingPower = 20f;
    private float movementSpeed = 30f;
    private Vector3 Wurfabstand = new Vector3(1.5f, 0, 0);
    private float startPos;
    private Animator anim;
    private AudioSource playerAudio;


    private void Start() {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        startPos = transform.position.x;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);

        if (IsGrounded() == true)
        {
            anim.SetBool("isJumping", false);
        } else {
            dustParticle.Stop();
            anim.SetBool("isJumping", true);
        }

        if (transform.position.x < startPos)
        {
            if (transform.position.x < startPos - 2.7f)
            {
                Time.timeScale = 0;
            }
            rb.AddForce(Vector2.right * movementSpeed);
        } else if (rb.position.x > startPos)
        {
            //transform.position = new Vector2(startPos, transform.position.y);
            rb.velocity = new Vector2(0.1f, rb.velocity.y);
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            JumpSound();
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
            playerAudio.PlayOneShot(throwSound);
            Instantiate(projectilePrefab, transform.position + Wurfabstand, projectilePrefab.transform.rotation);
        }
    }


    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground"))
        {
             if(!dustParticle.isPlaying) dustParticle.Play();
        }
    }

    void JumpSound() {
        playerAudio.PlayOneShot(jumpSound);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Coin"))
        {
            playerAudio.PlayOneShot(pickupCoin);
            Destroy(other.gameObject);
        }
    }
}