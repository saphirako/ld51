using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private enum EnemyType { UNASSIGNED, Hedgehog, Derp, Eyeball, UFO, Squid, Jelly }
    private EnemyType[] flyers = { EnemyType.Jelly, EnemyType.UFO, EnemyType.Squid, EnemyType.Eyeball };
    private EnemyType[] shooters = { EnemyType.UFO, EnemyType.Eyeball };
    private EnemyType[] grounders = { EnemyType.Derp, EnemyType.Hedgehog };
    private EnemyType[] leftRighters = { EnemyType.Hedgehog, EnemyType.Squid };

    [SerializeField]
    private EnemyType enemyType;
    [SerializeField]
    private Vector2 enemySpawnHeightBounds;
    [SerializeField]
    private Vector2 enemySpeedMinMax;    
    private float enemySpeed;

    void Start() {
        enemySpeed = Random.Range(enemySpeedMinMax.x, enemySpeedMinMax.y);
        transform.position.Set(
            transform.position.x,
            Random.Range(enemySpawnHeightBounds.x, enemySpawnHeightBounds.y),
            transform.position.z
        );
    }

    void FixedUpdate() {
        // LeftRighter movement Logic:
        if (System.Array.IndexOf(leftRighters, enemyType) >= 0) transform.position = new Vector2(transform.position.x + enemySpeed, transform.position.y);
    }
}
