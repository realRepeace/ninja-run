using UnityEngine;

public class BossEffects : MonoBehaviour
{
    public ParticleSystem hitParticles;

    public void ParticleHitParticles()
    {
        hitParticles.Play();
    }
}
