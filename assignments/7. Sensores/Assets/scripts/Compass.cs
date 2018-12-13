using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour {

    public static Compass Instance {
        set; get;
    }

	void Start () {
        Instance = this;
        DontDestroyOnLoad(gameObject);
	}

    public float Heading {
        get {
            return Input.compass.trueHeading;
        }
    }
}
