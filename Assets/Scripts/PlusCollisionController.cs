using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusCollisionController : MonoBehaviour {

    private void Start()
    {
        CollisionDetection.collisionDetectionInstance.pluscollision += IncrementPower;
    }

    void IncrementPower() {
        CollisionDetection.powerIndex++;
    }
}
