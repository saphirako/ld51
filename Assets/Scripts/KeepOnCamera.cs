using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepOnCamera : MonoBehaviour {
    void FixedUpdate() {
        if (GameManager.instance.State != GameManager.GameState.Menu) transform.position = new Vector3(transform.position.x + GameManager.instance.ForwardMomentum, transform.position.y, transform.position.z);
    }
}
