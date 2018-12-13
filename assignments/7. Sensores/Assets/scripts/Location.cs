using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour {

	void Start () {
        StartCoroutine(InitializeLocation());
	}

    private IEnumerator InitializeLocation() {
        if (!Input.location.isEnabledByUser) {
            Debug.Log("location disabled by user");
            yield break;
        }

        Input.compass.enabled = true;

        Debug.Log("Start location service");

        Input.location.Start(10, 0.01f);

        int maxSecondsToWaitForLocation = 20;

        while (Input.location.status == LocationServiceStatus.Initializing 
               && maxSecondsToWaitForLocation > 0) {
            yield return new WaitForSeconds(1);
            maxSecondsToWaitForLocation -= 1;
        }

        if (maxSecondsToWaitForLocation < 1) {
            Debug.Log("Location service timeout");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed) {
            Debug.Log("Unable to determine device location");
            yield break;
        }

        Debug.Log("Location service loaded");
        yield break;
    }
}
