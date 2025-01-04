using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.Audio;

public class UpdateLock : MonoBehaviour, IInteractable
{
    public AudioClip[] sounds;
    public PlayerController player;
    public NavMeshAgent anomaly;
    public GameObject keypadUI;
    public Text[] inputSlots; // Array to store the 7 
    public Text resultDisplay; // Text to display "SUCCESS" or "ERROR"
    private string enteredCode = ""; // Stores the code entered by the user
    private string correctCode = "1906516"; // The correct code
    private AudioSource keypadSound;

    private void Start()
    {
        keypadUI.SetActive(false);
        keypadSound = GetComponent<AudioSource>();
    }

    public void AddDigit(string digit)
    {
        if (enteredCode.Length < inputSlots.Length) // Limit to the number of slots
        {
            keypadSound.PlayOneShot(sounds[0]);

            enteredCode += digit;
            Debug.Log("Button pressed: " + digit);

            UpdateInputDisplay();
        }
    }

    public void Backspace()
    {
        if (enteredCode.Length > 0)
        {
            keypadSound.PlayOneShot(sounds[0]);

            enteredCode = enteredCode.Substring(0, enteredCode.Length - 1);
            UpdateInputDisplay();
        }
    }

    public void CheckCode()
    {
        if (enteredCode == correctCode)
        {
            keypadSound.PlayOneShot(sounds[2]);
            resultDisplay.text = "SUCCESS";
            resultDisplay.color = Color.green;
        }
        else
        {
            keypadSound.PlayOneShot(sounds[1]);
            resultDisplay.text = "ERROR";
            resultDisplay.color = Color.red;
        }
    }

    private void UpdateInputDisplay()
    {
        // Clear all slots first
        for (int i = 0; i < inputSlots.Length; i++)
        {
            inputSlots[i].text = "";
        }

        // Update slots with the entered code
        for (int i = 0; i < enteredCode.Length; i++)
        {
            inputSlots[i].text = enteredCode[i].ToString();
        }
    }

    public void Interact(Collider collider)
    {
        anomaly.isStopped = true;
        keypadUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.enabled = false;
    }

    public void ExitButton()
    {
        keypadUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player.enabled = true;
        anomaly.isStopped = false;
    }
}


