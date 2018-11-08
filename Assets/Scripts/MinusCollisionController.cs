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
        originalColor = this.GetComponent<Renderer>().material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            GameController.action = decreasePower;
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (GameObject barrel in GameObject.FindGameObjectsWithTag("MinusBarrel"))
        {
            barrel.GetComponent<Renderer>().material.color = originalColor;
        }
    }

    void decreasePower()
    {
        float red = Random.Range(0F, 1F);
        float green = Random.Range(0, 1F);
        float blue = Random.Range(0, 1F);

        if (GameController.powerScore > 0)
        {
            GameController.powerScore--;
            foreach (GameObject barrel in GameObject.FindGameObjectsWithTag("MinusBarrel"))
            {
                barrel.GetComponent<Renderer>().material.color = new Color(red, green, blue);
            }
            GameController.updateBoard();
        }
    }
}
