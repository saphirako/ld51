using UnityEngine;

public class EnemyManager : MonoBehaviour {
    [SerializeField]
    private Enemy[] enemyPrefabs;
    [SerializeField]
    private float enemyRespawnTiming;
    [SerializeField]
    private float phaseTwo;
    [SerializeField]
    private float phaseThree;
    private float spawnTimer;

    void Start() {
        spawnTimer = enemyRespawnTiming;
        enemyRespawnTiming = 4 - GameManager.instance.GamePhase;
    }

    void Update() {
        if (GameManager.instance.State == GameManager.GameState.Playing) {
            if (spawnTimer < 0) {
                spawnTimer = enemyRespawnTiming;
                var newEnemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)].gameObject, transform.position, transform.rotation);
            }

            else spawnTimer -= Time.deltaTime;

            // Up the ante when we get to a new phase (spawn quicker)
            enemyRespawnTiming = 4 - GameManager.instance.GamePhase;
        }
    }
}
