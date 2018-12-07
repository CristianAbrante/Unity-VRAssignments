using System;
using UnityEngine;

public class ObjectControl : MonoBehaviour
    {
    private Renderer rend;

    void Start() {
        rend = this.GetComponent<Renderer>();
    }
    void OnCollisionEnter(Collision collision)
    {
        rend.material.SetColor("_Color", new Color(0, 0, 0));
    }

    void OnCollisionExit(Collision collision)
    {
        rend.material.SetColor("_Color", new Color(255, 255, 255));
    }

    private void Update()
        {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Vector3 position = this.transform.position;
            position.x--;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Vector3 position = this.transform.position;
            position.x++;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            Vector3 position = this.transform.position;
            position.z++;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Vector3 position = this.transform.position;
            position.z--;
            this.transform.position = position;
        }
    }

}
