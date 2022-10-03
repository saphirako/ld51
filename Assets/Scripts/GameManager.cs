using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour {
    // Declare singleton
    public static GameManager instance;
    public enum GameState { Menu, Starting, Playing, GameOver };
    public GameState State { get; private set; }
    private PlayerInput input;
    private PlayerManager playerManager;
    private AudioSource music;

    public float ForwardMomentum;
    public float Score { get; private set; }
    public float GamePhase { get; private set; }
    public float TimeToScore;
    private float tenSecondTimer;


    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this);
            return;
        }
        else instance = this;

        input = new PlayerInput();
        instance.State = GameState.Menu;
        instance.playerManager = GetComponentInChildren<PlayerManager>(true);
        instance.tenSecondTimer = 10f;
        instance.music = GameObject.Find("Music Manager").GetComponent<AudioSource>();

        DontDestroyOnLoad(this);
    }

    void Start() {
        GamePhase = 1;

        input.UI.Click.performed += StartGame;
        ToggleClickAction(true);
    }

    void FixedUpdate() {
        if (instance.State == GameState.Playing) {
            instance.tenSecondTimer -= Time.deltaTime;
            if (instance.tenSecondTimer <= 0) {
                playerManager.UpdateWeapon();
                instance.tenSecondTimer = 10f;
            }
        }
    }
    public void IncrementScore(int deltaPoints) {
        Score += deltaPoints;
    }
    public void PlayGame() {
        instance.State = GameState.Playing;
        UIManager.instance.Clear();
    }

    private void ToggleClickAction(bool turnOn) {
        if (turnOn) input.UI.Click.Enable(); else input.UI.Click.Disable();
    }
    private void StartGame(InputAction.CallbackContext context) {
        if (instance.State == GameState.Menu) {
            var mousePosition = Input.mousePosition;
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, mousePosition - Camera.main.ScreenToWorldPoint(mousePosition), Mathf.Infinity);

            // If we hit nothing or we hit one of the boundary/triggers, start the game and turn off UI clicking
            if (!hit || hit.collider.tag == "Boundary") {
                UIManager.instance.Clear();
                ToggleClickAction(false);
                playerManager.Spawn();
                music.Play();
            }
        }
    }

    public void GameOver() {
        instance.State = GameState.GameOver;
        playerManager.KillPlayer();
        UIManager.instance.GameOverScreen();
    }
}
