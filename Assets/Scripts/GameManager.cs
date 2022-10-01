using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    // Declare singleton
    private static GameManager instance;
    private void Awake() {
        if (instance != null && instance != this) {
            Destroy(this);
            return;
        }
        else instance = this;
        DontDestroyOnLoad(this);
    }

}
