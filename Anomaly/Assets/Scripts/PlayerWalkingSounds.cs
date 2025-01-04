using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkingSounds : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] private AudioClip[] footstepSounds;
    [SerializeField] private float minTimeBetweenSteps = 0.8f;
    [SerializeField] private float movementCap = 10.0f;

    private AudioSource playerAudio;
    private PlayerController playerController;
    private Rigidbody rb;
    private float timeSinceLastStep;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerController = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastStep += Time.deltaTime;

        float horizontalSpeed = new Vector2(rb.velocity.x, rb.velocity.z).magnitude;

        if (horizontalSpeed > movementCap && playerController.grounded)
        {
            if (timeSinceLastStep >= GetStepInterval())
            {
                PlayFootstep();
            }
        }
    }

    private void PlayFootstep()
    {
        playerAudio.PlayOneShot(footstepSounds[Random.Range(0, footstepSounds.Length)]);

        timeSinceLastStep = 0;
    }

    private float GetStepInterval()
    {
        return playerController.isSprinting ? 0.58f : minTimeBetweenSteps;
    }
}
