using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour      //regelt das Verhalten des Schwerts z.B. Knockback des Spielers oder Schaden an Gegner
{
    private float damage = 1f;
    private float horizontalKnockback = 14f;
    private float verticalKnockback = 14f;
    public Rigidbody2D playerRb;
    public PlayerMovement _playerMovement;

        private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent))
        {
            enemyComponent.TakeDamage(damage);
            if (_playerMovement.IsGrounded() == true)
            {
                other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * horizontalKnockback, ForceMode2D.Impulse);
            } else {
                _playerMovement.ResetVelocity(playerRb);
                playerRb.AddForce(Vector2.up * verticalKnockback, ForceMode2D.Impulse);
            }
        }
        if (other.gameObject.CompareTag("Pilz"))
        {
            _playerMovement.ResetVelocity(playerRb);
            playerRb.AddForce(Vector2.up * verticalKnockback * 1.5f, ForceMode2D.Impulse);
        }
        } 
}
