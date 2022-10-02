using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    [SerializeField]
    private PlayerController playerPrefab;
    private PlayerController player;

    public void Spawn() {
        if (GameManager.instance.State == GameManager.GameState.Menu)
            player = Instantiate(playerPrefab.gameObject, transform.position, transform.rotation).GetComponent<PlayerController>();
    }

    public PlayerController GetPlayer() {
        return player;
    }

    public void KillPlayer(){
        Destroy(player.gameObject);
        player = null;
    }

    public void UpdateWeapon() {
        player.UpdateWeapon();
    }
}
