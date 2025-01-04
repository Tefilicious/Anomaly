using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulb : MonoBehaviour
{
    public AudioClip flickerSound;
    private AudioSource audioSource;
    private Animator lightBulb;
    private float startDelay = 5.0f;
    private float repeatRate = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        lightBulb = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("FlickerLight", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FlickerLight()
    {
        lightBulb.Play("Flicker");
        audioSource.PlayOneShot(flickerSound);
    }
}
