using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reference: https://www.youtube.com/watch?v=zit45k6CUMk

public class Parallax : MonoBehaviour {
    private Camera cam;
    [SerializeField]
    private float length, startPos;
    [SerializeField]
    private float paralaxEffect;
    private int offset;
    
    void Start() {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = UIManager.instance.MainCamera;
        offset = transform.parent.childCount;
    }
    
    void FixedUpdate() {
        float lookAhead = cam.transform.position.x * (1 - paralaxEffect);
        float deltaX = cam.transform.position.x * paralaxEffect;

        // Move the sprite according to the parallax factor
        transform.position = new Vector3(startPos + deltaX, transform.position.y, transform.position.z);

        // Edge cases:
        if (lookAhead > startPos + length) startPos += (length * offset); //Catch the fall-off on the right
    }

}
