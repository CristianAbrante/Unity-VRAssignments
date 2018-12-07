using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour {

    public Renderer rend;

    void Start() {
        rend = GetComponent<Renderer>();
    }
    void OnCollisionEnter(Collision collision)
    {
        rend.material.SetColor("_Color", new Color(255, 255, 0));
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 5)
            rend.material.SetColor("_Color", new Color(255, 0, 0));
    }

    void OnCollisionExit(Collision collision)
    {
        rend.material.SetColor("_Color", new Color(255, 255, 255));
    }
}
