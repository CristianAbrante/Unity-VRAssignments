using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void collisionAction();

public class MinusCollisionController : MonoBehaviour
{
    public static event collisionAction onCollision;
    private Color originalColor;

    public void Start()
    {
        GameController.onMinusCollition += changeColor;
        originalColor = this.GetComponent<Renderer>().material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameController.decrementScore();
        }
    }

    void changeColor() {
        this.GetComponent<Renderer>().material.color = Color.white;
        Invoke("restoreColor", 1);
    }

    void restoreColor() {
        this.GetComponent<Renderer>().material.color = originalColor;
    }

}
