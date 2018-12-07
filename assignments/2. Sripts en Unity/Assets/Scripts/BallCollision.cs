using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    private GameObject counter;
    private int times;

    void Start() {
           counter = GameObject.Find("CollisionCounter");
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Ethan") {
            counter.GetComponent("TextMesh").GetComponent<TextMesh>().text = "Collision Counter: " + times++;
        }
    }


}
