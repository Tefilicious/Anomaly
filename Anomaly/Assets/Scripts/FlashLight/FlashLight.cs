using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject flashLight;

    public bool flashLightOn;
    public bool flashLightOff;

    // Start is called before the first frame update
    void Start()
    {
        flashLightOff = true;
        flashLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (flashLightOff && Input.GetButtonDown("Flashlight"))
        {
            flashLight.SetActive(true);
            flashLightOn = true;
            flashLightOff = false;
        }
        else if (flashLightOn && Input.GetButtonDown("Flashlight"))
        {
            flashLight.SetActive(false);
            flashLightOn = false;
            flashLightOff = true;
        }
    }
}
