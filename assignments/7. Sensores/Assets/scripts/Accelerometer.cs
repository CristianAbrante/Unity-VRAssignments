using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Accelerometer : MonoBehaviour {

    public Text accelerometerText;
	
	void Update () {
        accelerometerText.text = "Accelerometer: " + Input.acceleration;
	}
}
