using UnityEngine;

public class StartGame : MonoBehaviour {
    private Collider2D trigger;

    void Awake() {
        trigger = GetComponent<Collider2D>();
        trigger.enabled = true;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            GameManager.instance.PlayGame();
            trigger.enabled = false;
        }
    }

    public void Reset() {
        trigger.enabled = true;
    }
}
