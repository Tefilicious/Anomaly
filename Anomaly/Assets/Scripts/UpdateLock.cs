using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLock : MonoBehaviour
{
    public Text[] inputSlots; // Array to store the 7 textboxes
    public Text resultDisplay; // Text to display "SUCCESS" or "ERROR"
    private string enteredCode = ""; // Stores the code entered by the user
    private string correctCode = "1906516"; // The correct code

    public void AddDigit(string digit)
    {
        if (enteredCode.Length < inputSlots.Length) // Limit to the number of slots
        {
            enteredCode += digit;
            Debug.Log("Button pressed: " + digit);

            UpdateInputDisplay();
        }
    }

    public void Backspace()
    {
        if (enteredCode.Length > 0)
        {
            enteredCode = enteredCode.Substring(0, enteredCode.Length - 1);
            UpdateInputDisplay();
        }
    }

    public void CheckCode()
    {
        if (enteredCode == correctCode)
        {
            resultDisplay.text = "SUCCESS";
            resultDisplay.color = Color.green;
        }
        else
        {
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
}


