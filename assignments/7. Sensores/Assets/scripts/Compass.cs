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
        StartCoroutine(StartLocationService());
	}
	
    private IEnumerator StartLocationService() {
        if (Input.location.isEnabledByUser) {
            Debug.Log("User has not enabled GPS.");
            yield break;
        }
        Input.location.Start(10, 0.01f);
        Input.compass.enabled = true;

        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing 
               && maxWait > 0) {
            yield return new WaitForSeconds(1);
            maxWait -= 1;
        }
        if (maxWait < 1) {
            Debug.Log("Timed out.");
            yield break;
        }
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determine device location.");
            yield break;
        }
        Debug.Log(Input.location.status);
        Debug.Log("location service loadeda");
        trueHeading = Input.compass.trueHeading;
    }
}
