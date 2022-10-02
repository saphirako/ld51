using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour {
    private enum WeaponType {
        UNEQUIPED,
        Pistol,
        Watergun,
        Minigun,
        Lazer,
        PurpleThing,
        BeeBeegun,
        Flamethrower,
        RPG
    }
    [SerializeField]
    private WeaponType type;
    [SerializeField]
    private Projectile projectile;

    [SerializeField]
    protected int rateOfFire;
    protected float timer;
    protected Vector2 direction;

    void Update() {
        // Refernce: https://www.youtube.com/watch?v=Geb_PnF1wOk
        direction = Mouse.current.position.ReadValue() - (Vector2)Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (timer > 0) timer -= Time.deltaTime;
    }

    public void Fire(InputAction.CallbackContext context) {
        if (timer <= 0) {
            var bullet = Instantiate(projectile.gameObject, transform.position, transform.rotation).GetComponent<Projectile>();
            bullet.Launch(direction);
        }
    }
}
