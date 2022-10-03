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
    private enum WeaponSound {
        BeeBeeGun,
        Flamethrower,
        Laser,
        Minigun,
        Pistol,
        PlasmaLauncher,
        RocketPod,
        Watergun
    }
    [SerializeField]
    private WeaponSound sound;
    [SerializeField]
    protected int rateOfFire;
    protected float timer;
    protected Vector2 direction;

    void Update() {
        // Refernce: https://www.youtube.com/watch?v=Geb_PnF1wOk
        direction = Mouse.current.position.ReadValue() - (Vector2)Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        // TODO: Limit weapon rotation to ahead of us
        // if (transform.rotation.z > 65) transform.Rotate(transform.rotation.x, transform.rotation.y, 65f, Space.Self);
        // else if (transform.rotation.z < -65) transform.Rotate(transform.rotation.x, transform.rotation.y, -65f, Space.Self);

        if (timer > 0) timer -= Time.deltaTime;
    }

    public void Fire(InputAction.CallbackContext context) {
        if (timer <= 0) {
            var bullet = Instantiate(projectile.gameObject, transform.position, transform.rotation).GetComponent<Projectile>();
            bullet.Launch(direction);
            AudioManager.Instance.Play(sound.ToString());
        }
    }
}
