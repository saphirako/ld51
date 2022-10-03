using UnityEngine;

public class UIManager : MonoBehaviour {
    public static UIManager instance;
    public Camera MainCamera;
    [SerializeField]
    private TMPro.TextMeshProUGUI playerScore;
    [SerializeField]
    private GameObject titleScreen;

    // Singleton declaration
    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this);
            return;
        }
        else instance = this;
        DontDestroyOnLoad(this);
    }

    void Start() {
        instance.MainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    void FixedUpdate() {
        if (GameManager.instance.State == GameManager.GameState.Playing)
            playerScore.SetText($"{GameManager.instance.Score}");
    }

    public void ToggleTitleScreen(bool show){
        instance.titleScreen.SetActive(show);
    }
}
