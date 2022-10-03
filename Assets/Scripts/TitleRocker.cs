using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleRocker : MonoBehaviour {
    [SerializeField]
    private TMPro.TextMeshProUGUI text;

    [SerializeField]
    private float tiltIntensity, scalingIntensity, flashIntensity;
    private float tilt, scaler, flasher;
    void Awake() {
        tilt = 0f;
        scaler = .5f;
        flasher = .5f;
    }
    void FixedUpdate() {
        tilt += Time.deltaTime;
        scaler += Time.deltaTime;
        flasher += Time.deltaTime;

        transform.Rotate(new Vector3(0f, 0f, (Mathf.Sin(tilt) * tiltIntensity)), Space.Self);


        if (text) {
            text.color = new Color(text.color.r, text.color.g, text.color.b, .75f + (Mathf.Cos(flasher) * flashIntensity));
            text.fontSize = text.fontSize + (Mathf.Cos(scaler) * scalingIntensity);
        }

        else {
            transform.localScale =  new Vector3(
                Mathf.Abs(transform.localScale.x + (Mathf.Cos(scaler) * scalingIntensity)),
                Mathf.Abs(transform.localScale.y + (Mathf.Cos(scaler) * scalingIntensity)),
                transform.localScale.z
            );
        }

    }

}
