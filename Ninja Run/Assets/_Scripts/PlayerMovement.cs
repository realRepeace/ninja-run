using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour     //regelt das Verhalten des Spielers z.B. Springen, Lebenanzahl, Animationen, Partikel
{
    [Header ("Prefabs")]
    public Rigidbody2D rb;
    public GameObject projectilePrefab;
    public GameObject kunaiPrefab;
    public GameObject schwertUntenPrefab;
    public GameObject schwertSeitePrefab;
    public Transform groundCheck;
    public LayerMask groundLayer;

    [Header ("Scripts")]
    public GameOverScript gameOverScript;
    public ZoomEffect zoomEffect;
    public CoinManager coinManager;

    [Header ("Particle")]
    public ParticleSystem dustParticle;
    public ParticleSystem damageTakenParticle;
    public ParticleSystem deathParticle;
    public ParticleSystem chargeAttackParticle;
    public ParticleSystem attackChargedParticle;
    public ParticleSystem attackChargedAura;

    [Header ("iFrames")]
    public float iFramesDuration;
    
    [Header ("Health")]
    public float maxHealth = 3f;
    public float currentHealth = 0f;
    
    
    
    private bool inputOnGround = true;
    private bool attackChargedOnce = true;
    public bool iFramesActive = false;
    private float jumpingPower = 20f;
    private float movementSpeed = 30f;
    private float nextTimeToFire = 0f;
    private float fireRate = 7f;
    private float nextTimeToAttack = 0f;
    private float attackRate = 7f;
    private float chargeTime = 1.5f;
    private Vector3 wurfabstand = new Vector3(1.5f, 0, 0);
    private float startPos;
    private Animator anim;
    private AudioSource playerAudio;
    private PlayerInput input;

    private float timer;
    private bool timerOn;


    private void Start() {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        input = GetComponent<PlayerInput>();
        currentHealth = maxHealth;
        startPos = rb.position.x;
        timer = 0;
        PauseMenu.GameIsPaused = false;
        if (!FindObjectOfType<InputManager>().playerActionMapActive)
        {
            FindObjectOfType<InputManager>().SwitchActionMap();
        }
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

        IsPlayerDead();
        
        if (currentHealth > 0)
        {
            Timer();
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
            Instantiate(projectilePrefab, transform.position + wurfabstand, projectilePrefab.transform.rotation);
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

    public void SpecialAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            timerOn = true;
            attackChargedOnce = true;
        }

        if (context.canceled)
        {
            chargeAttackParticle.Stop();
            attackChargedAura.Stop();
            if (timer > chargeTime)
            {
                rb.AddForce(Vector2.left * 10, ForceMode2D.Impulse);
                Instantiate(kunaiPrefab, transform.position + wurfabstand, kunaiPrefab.transform.rotation);
            } 
            timerOn = false;
        }

    }

    void Timer()
    {
        if (timerOn)
        {
            timer += Time.deltaTime;
            if (timer > 0.1f)
            {
                zoomEffect.ZoomScreen();
                chargeAttackParticle.Play();
            }
        }
        else{
            timer = 0;
            zoomEffect.ZoomOut();
        }
        if (timer > chargeTime)
        {
             chargeAttackParticle.Stop();
             if (attackChargedOnce)
             {
                attackChargedParticle.Play();
                attackChargedAura.Play();
                attackChargedOnce = false;
             }
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
            anim.SetTrigger("damageTaken");
            Instantiate(damageTakenParticle, transform.position, transform.rotation) ;
            if (currentHealth > 0)
            {
                FindObjectOfType<Hitstop>().Stop(0.3f);
                StartCoroutine(Invulnerability());
            } else {
                GameOver();
            }
            }
        }

        if (other.gameObject.CompareTag("Pilz"))
        {
            ResetVelocity(rb);
            rb.AddForce(Vector2.up * 10.5f, ForceMode2D.Impulse);
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
        gameOverScript.Setup(coinManager.currentLevelCoins);
        anim.SetTrigger("isDead");
        FindObjectOfType<InputManager>().SwitchActionMap();
        Instantiate(deathParticle, transform.position, transform.rotation) ;
        Time.timeScale = Mathf.Lerp(1, 0.1f, 50);
        gameObject.SetActive(false);
    }

    private void IsPlayerDead()
    {
        if (rb.position.x < startPos)
        {
            if (transform.position.x < startPos - 3.5f)
            {
                currentHealth = 0;
            }
            rb.AddForce(Vector2.right * movementSpeed);
            
        } 
        
        if (rb.position.x > startPos)
        {
            rb.position = new Vector2(startPos, rb.position.y);
        }

        if (transform.position.y < -6.36f)
        {
            currentHealth = 0;
        }

        if (currentHealth <= 0)
        {
            GameOver();
        } 
    }

    public void Pause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("PAUSE");
        }
    }
}