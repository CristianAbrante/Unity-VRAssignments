using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPS : MonoBehaviour {

    public static GPS Instance {
        set; get;
    }

    void Start() {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public float Latitude {
        get {
            return Input.location.lastData.latitude;
        }
    }

    public float Longitude {
        get {
            return Input.location.lastData.longitude;
        }
    }

    public float Altitude {
        get {
            return Input.location.lastData.altitude;
        }
    }
}

