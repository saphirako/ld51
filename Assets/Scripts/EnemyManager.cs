using UnityEngine;

public class EnemyManager : MonoBehaviour {
    [SerializeField]
    private Enemy[] enemyPrefabs;
    [SerializeField]
    private float enemyRespawnTiming;
    private float spawnTimer;

    void Start() {
        spawnTimer = enemyRespawnTiming;
    }
    
    void Update() {
        if (spawnTimer < 0) {
            spawnTimer = enemyRespawnTiming;
            var newEnemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)].gameObject, transform.position, transform.rotation);
        }

        else spawnTimer -= Time.deltaTime;
    }
}
