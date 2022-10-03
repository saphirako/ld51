using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {
    [SerializeField]
    private GameObject[] olives;
    private int index;

    void Awake(){
        index = olives.Length - 1;
    }
    public void RemoveOlives(int count){
        if (index - count < 0) {
            foreach (GameObject obj in olives) obj.SetActive(true);
        }
        else {
            for (int i = 0; i < count; i++) {
                olives[index].SetActive(false);
                index--;
            }
        }
    }

    void Reset(){
        foreach (GameObject obj in olives) obj.SetActive(true);
        index = olives.Length - 1;
    }
}
