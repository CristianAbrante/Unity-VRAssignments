using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlusCollisionController : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            IncreasePower();
    }

    public void IncreasePower() {
        GameController.powerScore++;
        GameController.updateBoard();
    }
   
}
