using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public float projectileSpeed;
    private Rigidbody2D rb;
    private string[] layersToKill = {"Entities", "Background", "Boundary"};
    [SerializeField]
    private float damage;

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


    void OnTriggerEnter2D(Collider2D other) {
        if (System.Array.IndexOf(layersToKill, other.gameObject.tag) >= 0) {
            Destroy(gameObject);
            return;
        }

        if (other.gameObject.tag == "Enemy") {
            other.gameObject.GetComponent<Enemy>().Damage(damage);
            Destroy(gameObject);
        }
    }
}
