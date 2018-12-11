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
        StartCoroutine(StartLocationService());
    }

    private IEnumerator StartLocationService() {
        if (isUnityRemote)
        {
            yield return new WaitForSeconds(5);
        }

        if (Input.location.isEnabledByUser) {
            Debug.Log("User has not enabled GPS.");
            yield break;
        }

        Input.location.Start(1, 0.01f);
        if (isUnityRemote)
        {
            yield return new WaitForSeconds(5);
        }
        int maxWait = 20;
        while(Input.location.status != LocationServiceStatus.Running && maxWait > 0) {
            yield return new WaitForSeconds(1);
            maxWait -= 1;
        }

        if (maxWait <= 0) {
            Debug.Log("Timed out.");
            yield break;
        }

        if (Input.location.status == LocationServiceStatus.Failed) {
            Debug.Log("Unable to determine device location.");
            yield break;
        } else {
            Debug.Log(Input.location.status);
            this.latitude = Input.location.lastData.latitude;
            this.longitude = Input.location.lastData.longitude;
            this.altitude = Input.location.lastData.altitude;
            yield break;
        }
    }
}
