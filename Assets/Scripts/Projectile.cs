using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public float projectileSpeed;
    private Rigidbody2D rb;
    private string[] layersToKill = {"Entities", "Background", "Boundary"};

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction){
        rb.AddForce(direction * projectileSpeed, ForceMode2D.Force);
    }

    public void Detonate() {
        // TODO: This is where the explosion would occur
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (System.Array.IndexOf(layersToKill, other.gameObject.tag) >= 0) {
            Destroy(this.gameObject);
            return;
        }
    }
}
