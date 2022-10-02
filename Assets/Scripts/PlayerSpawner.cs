using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour {
    [SerializeField]
    private PlayerController player;

    public void Spawn() {
        if (GameManager.instance.State == GameManager.GameState.Menu)
            Instantiate(player.gameObject, transform.position, transform.rotation);
    }
}
