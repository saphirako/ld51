using UnityEngine;

public class UIManager : MonoBehaviour {
    public static UIManager instance;
    public Camera MainCamera;
    public HealthBar VisualHealthBar;
    [SerializeField]
    private TMPro.TextMeshProUGUI playerScore;
    [SerializeField]
    private GameObject titleScreen;
    [SerializeField]
    private GameObject gameOverScreen;
    [SerializeField]
    private GameObject inGameScreen;
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
        instance.MainCamera = Camera.main;
        Clear();
        TitleScreen();
    }

    void FixedUpdate() {
        if (GameManager.instance.State == GameManager.GameState.Playing)
            playerScore.SetText($"{GameManager.instance.Score}");
    }

    public void Clear(){
        instance.titleScreen.SetActive(false);
        instance.gameOverScreen.SetActive(false);
        instance.inGameScreen.SetActive(false);
    }
    public void TitleScreen(){
        instance.Clear();
        instance.titleScreen.SetActive(true);
    }
    public void GameOverScreen(){
        instance.Clear();
        instance.gameOverScreen.SetActive(true);
    }
    public void InGameScreen(){
        instance.Clear();
        instance.inGameScreen.SetActive(true);
    }
}
