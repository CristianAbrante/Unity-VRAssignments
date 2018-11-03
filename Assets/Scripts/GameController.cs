using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour {

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) {
            GameObject candle = GameObject.FindGameObjectWithTag("Candle");
            candle.GetComponent<Light>().enabled = !candle.GetComponent<Light>().enabled;
        }

        
        //counter.GetComponent("TextMesh").GetComponent<TextMesh>().text = "Power: " + powerIndex;
    }

}

