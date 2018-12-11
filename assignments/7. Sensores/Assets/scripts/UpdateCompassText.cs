using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCompassText : MonoBehaviour {
    public Text compassText;
	
	// Update is called once per frame
	void Update () {
        compassText.text = 
            "Compass:" + Compass.Instance.trueHeading.ToString();
	}
}
