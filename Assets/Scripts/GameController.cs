using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static event Event EventHandler;
    public delegate void Event();

    public delegate void OnCollition();
    public static OnCollition action;

    public static GameController gameControllerInstance;

    private TextMesh powerScoreBoard;
    public static int powerScore;
    private Light lightEnabled;

    public void Start()
    {
        powerScoreBoard = GameObject.Find("CollisionCounter").GetComponent<TextMesh>();
        powerScore = 0;
        lightEnabled = GameObject.FindGameObjectWithTag("Candle").GetComponent<Light>();
    }

    public void Awake()
    {
        if (gameControllerInstance == null)
            gameControllerInstance = this;
        else if (gameControllerInstance != this)
            Destroy(gameObject);
    }

    public static void updateBoard() {
            gameControllerInstance.powerScoreBoard.text = "Power: " + powerScore;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) {
            lightEnabled.enabled = !lightEnabled.enabled;
        }

        if (action != null) {
            action();
            action = null;
        }


        
    }

}

