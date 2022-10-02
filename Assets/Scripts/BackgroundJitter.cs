using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundJitter : MonoBehaviour {
    [SerializeField]
    private float jitterFactor;
    private float jitter;
    void Awake() {
        jitter = .5f;
    }
    void FixedUpdate(){
        if (GameManager.instance.State != GameManager.GameState.Menu) {
            jitter += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y + (Mathf.Sin(jitter) * jitterFactor), transform.position.z);
        }
    }        
}
