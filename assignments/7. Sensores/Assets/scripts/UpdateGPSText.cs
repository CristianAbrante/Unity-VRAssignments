using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGPSText : MonoBehaviour {

    public Text gpsText;
	
	void Update () {
        string coordinates = "GPS: (";
        coordinates += round(GPS.Instance.Latitude).ToString() + ", ";
        coordinates += round(GPS.Instance.Longitude).ToString() + ", ";
        coordinates += round(GPS.Instance.Altitude).ToString() + ")";
        gpsText.text = coordinates;
	}

    private float round(float number) {
        return (float) System.Math.Round(number, 3);
    }
}
