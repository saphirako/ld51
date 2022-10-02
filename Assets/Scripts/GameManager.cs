using UnityEngine;

public class GameManager : MonoBehaviour {
    // Declare singleton
    public static GameManager instance;
    public float ForwardMomentum;
    public float Score { get; private set; }
    
    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this);
            return;
        }
        else instance = this;
        DontDestroyOnLoad(this);
    }

    public void IncrementScore(int deltaPoints) {
        Score += deltaPoints;
    }
}
