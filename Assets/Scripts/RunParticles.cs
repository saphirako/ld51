using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunParticles : MonoBehaviour
{
    private ParticleSystem pm;

    void Start() {
        pm = gameObject.GetComponent<ParticleSystem>();
    }

    public void Play() {
        pm.Play();
    }

    public void Stop() {
        pm.Stop();
    }
}
