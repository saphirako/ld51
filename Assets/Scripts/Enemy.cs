using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private SpriteRenderer sr;
    private enum EnemyType { UNASSIGNED, Hedgehog, Derp, Eyeball, UFO, Squid, Jelly }
    private EnemyType[] flyers = { EnemyType.Jelly, EnemyType.UFO, EnemyType.Squid, EnemyType.Eyeball };
    private EnemyType[] shooters = { EnemyType.UFO, EnemyType.Eyeball };
    private EnemyType[] grounders = { EnemyType.Derp, EnemyType.Hedgehog };
    private EnemyType[] leftRighters = { EnemyType.Hedgehog, EnemyType.Squid, EnemyType.Derp };

    [SerializeField]
    private EnemyType enemyType;
    [SerializeField]
    private Vector2 enemySpawnHeightBounds;
    [SerializeField]
    private Vector2 enemySpeedMinMax;    
    private float enemySpeed;
    private float spawnHeight;
    [SerializeField]
    private int damage;
    [SerializeField]
    private int points;
    [SerializeField]
    private float health;

    void Start() {
        enemySpeed = Random.Range(enemySpeedMinMax.x, enemySpeedMinMax.y);
        spawnHeight = Random.Range(enemySpawnHeightBounds.x, enemySpawnHeightBounds.y);
        transform.position.Set(
            transform.position.x,
            spawnHeight,
            transform.position.z
        );
        transform.Rotate(
            0f,
            transform.rotation.y + (enemySpeed > 0 ? 180f : 0f),
            0f,
            Space.Self
        );
    }

    void FixedUpdate() {
        // LeftRighter movement Logic:
        if (System.Array.IndexOf(leftRighters, enemyType) >= 0) transform.position = new Vector2(transform.position.x + enemySpeed, transform.position.y);

        // Jelly movement logic:
        if (enemyType == EnemyType.Jelly) transform.position = new Vector2(transform.position.x + enemySpeed, transform.position.y + (Mathf.Sin(Time.deltaTime) * enemySpeed * 2));
    }

    void OnCollisionEnter2D(Collision2D other) {
        // If we hit the ground or another enemy... that's ok.
        if (other.gameObject.name == "Ground" || other.gameObject.tag == "Enemy") return;
        
        // Otherwise we hit something else and, whatever that is, is gonna destroy us.
        // if (other.gameObject.tag == "Player") other.GetComponent<PlayerController>().TakeDamage(damage);

        // Finish him!!!
        Destroy(gameObject);
    }

    public void Damage(float damageDealt) {
        health -= damageDealt;
        if (health < 1) {
            Destroy(gameObject);
            // TODO: juice for death goes here
        }
        else {
            // TODO: juice for damage goes here
        }
    }
}