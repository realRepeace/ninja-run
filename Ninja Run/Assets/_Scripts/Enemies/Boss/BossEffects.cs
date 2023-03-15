using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEffects : MonoBehaviour
{
    public ParticleSystem hitParticles;

    public void ParticleHitParticles()
    {
        hitParticles.Play();
    }
}
