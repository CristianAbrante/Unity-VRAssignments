using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour {

    public static Compass Instance {
        set; get;
    }

    public float trueHeading;

	// Use this for initialization
	void Start () {
        Instance = this;
        DontDestroyOnLoad(gameObject);
	}
	
    public void UpdateCompass()
    {
        this.trueHeading = Input.compass.trueHeading;
    }
}
