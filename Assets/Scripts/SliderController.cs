using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour {

    public Slider lightSlider;
    public Slider sizeSlider;
    public GameObject lightControl;
    public GameObject sizeControl;

    

    // Use this for initialization
    void Start () {
		lightSlider.onValueChanged.AddListener(changeLightIntensity);
        sizeSlider.onValueChanged.AddListener(changeObjectSize);
    }

    private void changeLightIntensity(float value)
    {
        lightControl.GetComponent<Light>().intensity = value;
    }

    private void changeObjectSize(float value)
    {
        value *= 2;
        sizeControl.transform.localScale = new Vector3(value, value, value);
    }


}
