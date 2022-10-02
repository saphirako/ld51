using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    // Attached Assets:
    private Rigidbody2D rb;
    private Weapon weapon;
    private PlayerAnimationController pac;

    // Input Controls:
    private PlayerInput input;
    private InputAction movement;


    // Variables:
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float slideTime;
    [SerializeField]
    private float iFrameTime;
    private bool isGrounded;
    private bool isUpright;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        input = new PlayerInput();
        pac = GetComponent<PlayerAnimationController>();
        weapon = GetComponentInChildren(typeof(Weapon), false) as Weapon;
    }

    void OnEnable(){
        // Subscribe to "movement" (jump/slide) events
        input.Player.Move.performed += ProcessMovement;
        input.Player.Move.Enable();

        // Subscribe to fire events
        input.Player.Fire.performed += weapon.Fire;
        // input.Player.Fire.performed += GameManager.instance.StartGame;
        input.Player.Fire.Enable();
    }


    void FixedUpdate(){
        isUpright = isGrounded;
        if (GameManager.instance.State == GameManager.GameState.Menu) transform.position = new Vector3(transform.position.x + GameManager.instance.ForwardMomentum, transform.position.y, transform.position.z);
    }

    private void ProcessMovement(InputAction.CallbackContext context) {
        float yInput = context.ReadValue<Vector2>().y;

        // Trigger jumping
        if (isGrounded && isUpright && yInput > 0) {
            Debug.Log("Is jumping");
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
            pac.Jump();
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
        if(other.gameObject.name == "Ground") {
            isGrounded = true;
            pac.Run();
        }
    }
}
