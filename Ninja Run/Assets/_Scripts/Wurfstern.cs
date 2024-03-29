using UnityEngine;

public class Wurfstern : MonoBehaviour          //regelt das Verhalten der Wurfsterne z.B. Schaden an Gegner, Knockback
{
    public GameObject explosionParticle;

    public float speed = 40f;
    public float rotationSpeed = 150f;
    public float damage = 0.5f;
    public bool canExplode = false;

    private float rangeLimit = 11f;
    private float horizontalKnockback = 3f;
    private float explosionRadius = 3f;


    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
        
        transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime, Space.Self); 
        OutOfSight();
    }

    private void OutOfSight() 
    {
        if (transform.position.x >= rangeLimit)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent) && !canExplode)
        {
            enemyComponent.TakeDamage(damage);
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * horizontalKnockback, ForceMode2D.Impulse);
        }
        if (other.gameObject.TryGetComponent<BossHealth>(out BossHealth bossComponent))
        {
            bossComponent.BossTakeDamage(damage);
        }
        if (canExplode)
        {
            Explode(other);
        }
        Destroy(gameObject);
    } 

    private void Explode(Collider2D other)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
	    Instantiate(explosionParticle, other.transform.position, transform.rotation);

        foreach(Collider2D hit in colliders)
        {
            if (hit.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
            {
                enemyComponent.TakeDamage(damage);
                hit.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * horizontalKnockback, ForceMode2D.Impulse);
            }
        }
    }
}