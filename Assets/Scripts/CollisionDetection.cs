using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void collisionAction();

public class CollisionDetection : MonoBehaviour {
    public static CollisionDetection collisionDetectionInstance;         //A reference to our game control script so we can access it statically.
    public event collisionAction pluscollision;
    public event collisionAction minusCollision;
    private float colorStartTime = 0.0f;
    private GameObject counter;
    public static int powerIndex;

    private void Awake()
    {
        //If we don't currently have a game control...
        if (collisionDetectionInstance == null)
            //...set this one to be it...
            collisionDetectionInstance = this;
        //...otherwise...
        else if (collisionDetectionInstance != this)
            //...destroy this one because it is a duplicate.
            Destroy(gameObject);
    }

    // Use this for initialization
    void Start () {
        counter = GameObject.Find("CollisionCounter");
    }


    private void OnCollisionEnter(Collision collisionInfo)
    {

        if (collisionInfo.collider.tag == "MinusBarrel")
            minusCollision();

        else if (collisionInfo.collider.tag == "PlusBarrel")
            pluscollision();

        counter.GetComponent("TextMesh").GetComponent<TextMesh>().text = "Power: " + powerIndex;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            GameObject candle = GameObject.FindGameObjectWithTag("Candle");
            candle.GetComponent<Light>().enabled = !candle.GetComponent<Light>().enabled;
        }
    }
}
