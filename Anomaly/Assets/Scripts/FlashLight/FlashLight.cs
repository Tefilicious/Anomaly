using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject flashLight;
    public AudioClip flashlightSound;
    public bool flashLightOn;
    public bool flashLightOff;

    private AudioSource player;

    // Start is called before the first frame update
    void Start()
    {
        flashLightOff = true;
        flashLight.SetActive(false);
        player = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flashLightOff && Input.GetButtonDown("Flashlight"))
        {
            player.PlayOneShot(flashlightSound);
            flashLight.SetActive(true);
            flashLightOn = true;
            flashLightOff = false;
        }
        else if (flashLightOn && Input.GetButtonDown("Flashlight"))
        {
            player.PlayOneShot(flashlightSound);
            flashLight.SetActive(false);
            flashLightOn = false;
            flashLightOff = true;
        }
    }
}
