using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGPSText : MonoBehaviour {
    public Text gpsText;
	// Update is called once per frame
	void Update () {
        gpsText.text =
            "Latitude(" + GPS.Instance.latitude.ToString() + "), " +
            "Longitude(" + GPS.Instance.longitude.ToString() + "), " +
            "Altitude(" + GPS.Instance.altitude.ToString() + ")";
	}
}
