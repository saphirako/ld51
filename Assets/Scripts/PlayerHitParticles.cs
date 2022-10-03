using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitParticles : MonoBehaviour
{
    private ParticleSystem pm;

    void Start() {
        pm = gameObject.GetComponent<ParticleSystem>();
    }

    public void Play() {
        pm.Play();
    }
}
