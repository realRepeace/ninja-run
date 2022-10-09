using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Prefabs")]
    public Rigidbody2D rb;
    public GameObject projectilePrefab;
    public GameObject schwertUntenPrefab;
    public GameObject schwertSeitePrefab;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public GameOverScript gameOverScript;

    [Header ("Particle")]
    public ParticleSystem dustParticle;

    [Header ("iFrames")]
    public float iFramesDuration;
    
    [Header ("Health")]
    public float maxHealth = 3f;
    public float currentHealth = 0f;
    
    
    
    private bool inputOnGround = true;
    private bool iFramesActive = false;
    private float jumpingPower = 20f;
    private float movementSpeed = 30f;
    private float nextTimeToFire = 0f;
    private float fireRate = 7f;
    private float nextTimeToAttack = 0f;
    private float attackRate = 7f;
    private Vector3 Wurfabstand = new Vector3(1.5f, 0, 0);
    private float startPos;
    private Animator anim;
    private AudioSource playerAudio;
    private PlayerInput input;


    private void Start() {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        input = GetComponent<PlayerInput>();
        currentHealth = maxHealth;
        startPos = rb.position.x;
    }

    void FixedUpdate() //Abfragen ob Spieler tod ist und Animationen
    {

        if (IsGrounded() == true)
        {
            anim.SetBool("isJumping", false);
        } else {
            dustParticle.Stop();
            anim.SetBool("isJumping", true);
        }

        if (rb.position.x < startPos)
        {
            if (transform.position.x < startPos - 3.5f)
            {
                GameOver();
            }
            rb.AddForce(Vector2.right * movementSpeed);
            
        } 
        
        if (rb.position.x > startPos)
        {
            rb.position = new Vector2(startPos, rb.position.y);
           //rb.velocity = new Vector2(0.1f, rb.velocity.y);
        }

        if (transform.position.y < -6.36f)
        {
            GameOver();
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
        if (context.performed && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            FindObjectOfType<AudioManager>().Play("throwsound");
            Instantiate(projectilePrefab, transform.position + Wurfabstand, projectilePrefab.transform.rotation);
        }
    }

    public void Schwert(InputAction.CallbackContext context)
    {
        if (context.performed && Time.time >= nextTimeToAttack)
        {
            nextTimeToAttack = Time.time + 1f / attackRate;
            if (IsGrounded() == false)
            {
                schwertUntenPrefab.SetActive(true);
                inputOnGround = false;
            } else {
                schwertSeitePrefab.SetActive(true);
                inputOnGround = true;
            }

            StartCoroutine(SchwertDelay());
        }
    }

    IEnumerator SchwertDelay() //Damit Schwert nicht gespamt werden kann 
    {
        yield return new WaitForSecondsRealtime(0.1f);

        if (inputOnGround == true)
        {
            schwertSeitePrefab.SetActive(false);
        } else {
            schwertUntenPrefab.SetActive(false);
        }
        
    }


    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    
    private void OnCollisionEnter2D(Collision2D other) { //Zusammenstoß mit anderen Objekten wird geregelt
        
        if (other.gameObject.CompareTag("Ground"))
        {
             if(!dustParticle.isPlaying) dustParticle.Play();
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            if (iFramesActive == false)
            {
            currentHealth -= 1;
            if (currentHealth > 0)
            {
                anim.SetTrigger("damageTaken");
                FindObjectOfType<Hitstop>().Stop(0.2f);
                StartCoroutine(Invulnerability());
            } else if (currentHealth == 0) {
                GameOver();
            }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) { //Zusammenstoß mit anderen Triggerobjekten wird geregelt 
        if (other.gameObject.CompareTag("Coin"))
        {
            CoinManager.coinAmount += 1;
            FindObjectOfType<AudioManager>().Play("pickupCoin");
            Destroy(other.gameObject);
        }
    }

    public void ResetVelocity(Rigidbody2D rb) 
    {
        rb.velocity = Vector2.zero;

    }

    public void JumpSound()
    {
        FindObjectOfType<AudioManager>().Play("jumpsound");
    }

    private IEnumerator Invulnerability()
    {
        iFramesActive = true;

        yield return new WaitForSeconds(iFramesDuration);

        iFramesActive = false;
    }

    public void GameOver() 
    {
        gameOverScript.Setup(CoinManager.coinAmount);

        anim.SetTrigger("isDead");
        input.actions.Disable();
        Time.timeScale = 0;
    }
}