using UnityEngine;

public class BossHealth : MonoBehaviour          //Das Verhalten vom Gegner wird geregelt z.B. erhaltenen Schaden
{
    public Rigidbody2D rb;
    public GameObject hitSplashSmall;
    public HitFlash hitFlash;
    public float bossHealth, bossHealthEnrageAmount, bossMaxHealth;
    public bool invincibility = false;

    private void Start() {
        bossHealth = bossMaxHealth;

    }

    public void BossTakeDamage(float damage) //Alle zusammenhängenden Aktionen werden abgespielt, wenn der Gegner Schaden erleidet
    {
        if (invincibility) return;
    
        bossHealth -= damage;
        Instantiate(hitSplashSmall, transform.position, Quaternion.identity);
        hitFlash.Flash();
        FindObjectOfType<AudioManager>().Play("enemydamage");
        
        if (bossHealth <= bossHealthEnrageAmount)
        {
            GetComponent<Animator>().SetTrigger("IsEnraged");
        }

        if (bossHealth <= 0)
        {
            GetComponent<Animator>().SetTrigger("Dead");
        }
    }

    public void DestroyBoss()
    {
        Destroy(gameObject);
    }
}

