using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Camera MainCamera;

    // Singleton declaration
    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this);
            return;
        }
        else instance = this;
        DontDestroyOnLoad(this);
    }

    void Start() {
        instance.MainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }


}
