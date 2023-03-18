using UnityEngine;

public class BossEffects : MonoBehaviour    //Partikel werden abgespielt, wenn der Boss gehittet wird
{
    public ParticleSystem hitParticles;

    public void ParticleHitParticles()
    {
        hitParticles.Play();
    }
}
