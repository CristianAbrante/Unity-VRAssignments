using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

	void Start () {
        GameController.lightIntensity += SwitchLight;

    }
	
	void SwitchLight() {
        this.GetComponent<Light>().enabled = !this.GetComponent<Light>().enabled;
    }
}
