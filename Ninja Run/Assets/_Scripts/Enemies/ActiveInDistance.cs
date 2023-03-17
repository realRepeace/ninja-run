using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveInDistance : MonoBehaviour
{
    public Rigidbody2D player;  //Ich rufe den Rigidbody2D der Spielfigur auf
    public Rigidbody2D enemy;   //Ich rufe den Rigidbody2D des gegnerischen Objekts auf
    public float distanceToEnemy;   //Ich lege hiermit die Entfernung vom Spieler zum gegnerischen Objekt fest

    void Update()
    {
        if (player.position.x >= enemy.position.x - distanceToEnemy)    //Abfrage, ob die Spielfigur innerhalb der Reichweite ist
        {
            GetComponent<Animator>().SetTrigger("SetActiveInDistance");   //Die Spielfigur wird dadurch aktiv und spielt die Animationen ab
        }
    }
}
