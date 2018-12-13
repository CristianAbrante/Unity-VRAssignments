using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPS : MonoBehaviour {

    public static GPS Instance {
        set; get;
    }

    private const bool isUnityRemote = true;

    public float latitude;
    public float longitude;
    public float altitude;

    void Start() {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void UpdateGPS()
    {
        this.latitude = Input.location.lastData.latitude;
        this.longitude = Input.location.lastData.longitude;
        this.altitude = Input.location.lastData.altitude;
    }
}

