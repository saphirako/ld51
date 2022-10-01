using UnityEngine;

public class GameManager : MonoBehaviour {
    // Declare singleton
    public static GameManager instance;
    public float ForwardMomentum;
    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this);
            return;
        }
        else instance = this;
        DontDestroyOnLoad(this);
    }

}
