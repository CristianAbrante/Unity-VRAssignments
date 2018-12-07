using UnityEngine;
using System.Collections;

public class BallMovingController : MonoBehaviour
{
    public float speed;
    private Transform tf;

    void Start()
    {
        tf = GetComponent<Transform>();
    }

    void Update()
    {

        // Move the object forward along its z axis 1 unit/second.
        transform.Translate(0, 0, Time.deltaTime * speed);

    }
}