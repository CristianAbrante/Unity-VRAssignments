using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinusCollisionController : MonoBehaviour
{

    private bool changedColor = false;

    private void Start()
    {
        CollisionDetection.collisionDetectionInstance.minusCollision += DecrementPower;
        CollisionDetection.collisionDetectionInstance.minusCollision += ChangeColor;
    }

    void DecrementPower()
    {
        if(CollisionDetection.powerIndex > 0)
            CollisionDetection.powerIndex--;
    }

    void ChangeColor()
    {
        GameObject[] barrels = GameObject.FindGameObjectsWithTag("MinusBarrel");

        float red = Random.Range(0F, 1F);
        float green = Random.Range(0, 1F);
        float blue = Random.Range(0, 1F);

        foreach (GameObject barrel in barrels) {
            Renderer rend = barrel.GetComponent<Renderer>();
            rend.material.color = new Color(red, green, blue);

        }

    }
}
