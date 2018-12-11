using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Accelerometer : MonoBehaviour {

    public Text accelerometerText;
	
	// Update is called once per frame
	void Update () {
        if (Input.acceleration != null) {
            accelerometerText.text = "Accelerometer: " + Input.acceleration;
        }
	}
}
