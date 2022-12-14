using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    // Attached Assets:
    private Rigidbody2D rb;
    [SerializeField]
    private Weapon weapon;
    private PlayerAnimationController pac;
    private WeaponChangeParticles wcp;
    private LandParticles lp;
    private PlayerHitParticles php;
    private RunParticles rp;
    private AudioSource audioSource;

    // Input Controls:
    private PlayerInput input;
    private InputAction movement;


    // Variables:
    [SerializeField]
    private Weapon[] weapons;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float slideTime;
    [SerializeField]
    private float iFrameTime;
    public int Health { get; private set; }
    private bool isGrounded;
    private bool isUpright;
    private float scoreTimer;
    private int selectedWeapon;


    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        input = new PlayerInput();
        pac = GetComponent<PlayerAnimationController>();
        audioSource = GetComponent<AudioSource>();
        Health = 3;
        scoreTimer = GameManager.instance.TimeToScore;
        weapons = GetComponentsInChildren<Weapon>(true);
        wcp = GetComponentInChildren<WeaponChangeParticles>();
        lp = GetComponentInChildren<LandParticles>();
        php = GetComponentInChildren<PlayerHitParticles>();
        rp = GetComponentInChildren<RunParticles>();
        selectedWeapon = Random.Range(0, weapons.Length);
        weapons[selectedWeapon].gameObject.SetActive(true);
        weapon = weapons[selectedWeapon];
    }

    void OnEnable() {
        // Subscribe to "movement" (jump/slide) events
        input.Player.Move.performed += ProcessMovement;
        input.Player.Move.Enable();

        // Subscribe to fire events
        input.Player.Fire.performed += weapon.Fire;
        // input.Player.Fire.performed += GameManager.instance.StartGame;
        input.Player.Fire.Enable();


    }


    void FixedUpdate() {
        isUpright = isGrounded;
        if (GameManager.instance.State != GameManager.GameState.Playing) transform.position = new Vector3(transform.position.x + GameManager.instance.ForwardMomentum, transform.position.y, transform.position.z);
        if (GameManager.instance.State == GameManager.GameState.Playing && Health > 0) {
            if (scoreTimer < 0) {
                GameManager.instance.IncrementScore(1);
                scoreTimer = GameManager.instance.TimeToScore;
            }

            scoreTimer -= Time.deltaTime;
        }
    }

    private void ProcessMovement(InputAction.CallbackContext context) {
        float yInput = context.ReadValue<Vector2>().y;

        // Trigger jumping
        if (isGrounded && isUpright && yInput > 0) {
            // transform.Translate(new Vector3(0f,.1f,0f));
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
            pac.Jump();
            rp.Stop();
            audioSource.Stop();
            AudioManager.Instance.Play("Jump");
            return;
        }

        // Trigger sliding
        if (isGrounded && isUpright && yInput < 0) {
            Debug.Log("Is sliding");
            isUpright = false;
            pac.Slide();
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "Ground") {
            isGrounded = true;
            pac.Run();
            rp.Play();
            lp.Play();
            audioSource.Play();
        }
    }

    public void TakeDamage(int damage) {
        AudioManager.Instance.Play("PlayerHit");
        php.Play();
        Health -= damage;
        UIManager.instance.VisualHealthBar.RemoveOlives(damage);
        if (Health < 1) GameManager.instance.GameOver();
    }

    public void UpdateWeapon() {
        wcp.Play();
        int newWeapon;
        do {
            newWeapon = Random.Range(0, weapons.Length);
        } while (newWeapon == selectedWeapon);

        // Replace the currently active weapon with the new weapon
        weapons[newWeapon].gameObject.SetActive(true);
        input.Player.Fire.performed -= weapon.Fire;
        weapon = weapons[newWeapon];
        input.Player.Fire.performed += weapon.Fire;
        weapons[selectedWeapon].gameObject.SetActive(false);
        selectedWeapon = newWeapon;
    }

    void OnDestroy(){
        input.Player.Fire.performed -= weapon.Fire;
        input.Player.Fire.Disable();
    }
}
