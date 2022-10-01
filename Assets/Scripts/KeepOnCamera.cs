using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepOnCamera : MonoBehaviour {
    void FixedUpdate() {
        transform.position = new Vector3(transform.position.x + GameManager.instance.ForwardMomentum, transform.position.y, transform.position.z);
    }
}
