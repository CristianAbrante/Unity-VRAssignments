using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public delegate void genericEvent();
    public static event genericEvent onMinusCollition;
    public static event genericEvent lightIntensity;

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

    public static void decrementScore() {
        onMinusCollition();

        if (powerScore > 0)
        {
            powerScore--;
            updateBoard();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) {
            lightEnabled.enabled = !lightEnabled.enabled;
        }

    }

}

