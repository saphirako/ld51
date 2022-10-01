using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reference: https://www.youtube.com/watch?v=zit45k6CUMk

public class Parallax : MonoBehaviour {
    private Camera cam;
    private float length, startPos;
    public float ParalaxEffect;
    
    void Start() {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = UIManager.instance.MainCamera;
    }
    
    void FixedUpdate() {
        float lookAhead = cam.transform.position.x * (1 - ParalaxEffect);
        float deltaX = cam.transform.position.x * ParalaxEffect;

        // Move the sprite according to the parallax factor
        transform.position = new Vector3(startPos + deltaX, transform.position.y, transform.position.z);

        // Edge cases:
        if (lookAhead > startPos + length) startPos += length; //Catch the fall-off on the right
        else if (lookAhead < startPos - length) startPos -= length; //Catch the fall-off on the left (since we only move right, this is only for testing) 
    }

}
