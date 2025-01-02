using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BookPuzzleManager : MonoBehaviour
{
    public GameObject[] books; // Array of book GameObjects
    public string[] correctSequence = { "F", "S", "D", "A", "G" }; // Correct order
    private List<string> playerSequence = new List<string>(); // Tracks player's selections
    public GameObject messageUI; // UI element to show messages
    public TextMeshProUGUI roundCounterText; // UI text to show remaining rounds
    private int remainingRounds = 5; // Total rounds allowed

    void Start()
    {
        ResetPuzzle(); // Initialize the puzzle
        if (messageUI != null)
        {
            messageUI.SetActive(false); // Hide message UI at the start
        }
        UpdateRoundCounter(); // Display initial round count
    }

    public void BookSelected(string bookName)
    {
        Debug.Log($"Book Selected: {bookName}");

        // Add the selected book to the player's sequence
        playerSequence.Add(bookName);

        // Check if the player has made the required number of selections
        if (playerSequence.Count == correctSequence.Length)
        {
            if (IsCorrectSequence())
            {
                Debug.Log("Correct Combination!");
                ShowMessage("You solved the puzzle!");
                // Add logic to unlock the door or proceed to the next stage
            }
            else
            {
                remainingRounds--; // Decrement the round counter
                UpdateRoundCounter(); // Update the UI
                if (remainingRounds > 0)
                {
                    Debug.Log("Wrong Combination!");
                    ShowMessage("Try again, the Anomaly will find you!");
                    Invoke(nameof(ResetPuzzle), 2f); // Wait 2 seconds before resetting
                }
                else
                {
                    Debug.Log("Game Over!");
                    ShowMessage("Game Over! The Anomaly got you!");
                    // Add game over logic here, e.g., reload scene or show main menu
                }
            }
        }
    }

    private bool IsCorrectSequence()
    {
        for (int i = 0; i < correctSequence.Length; i++)
        {
            if (playerSequence[i] != correctSequence[i])
            {
                Debug.Log($"Incorrect sequence at position {i}: Expected {correctSequence[i]}, Got {playerSequence[i]}");
                return false;
            }
        }
        return true;
    }

    private void ResetPuzzle()
    {
        Debug.Log("Resetting Puzzle...");
        playerSequence.Clear(); // Clear the player's sequence
    }

    private void ShowMessage(string text)
    {
        if (messageUI == null)
        {
            Debug.LogError("messageUI is not assigned in the Inspector!");
            return;
        }

        var textComponent = messageUI.GetComponent<TextMeshProUGUI>();
        if (textComponent == null)
        {
            Debug.LogError("messageUI does not have a TextMeshProUGUI component!");
            return;
        }

        Debug.Log($"Showing Message: {text}");
        messageUI.SetActive(true);
        textComponent.text = text; // Set the message text
        Invoke(nameof(HideMessage), 2f); // Hide the message after 2 seconds
    }

    private void HideMessage()
    {
        if (messageUI != null)
        {
            messageUI.SetActive(false);
        }
    }

    private void UpdateRoundCounter()
    {
        if (roundCounterText != null)
        {
            roundCounterText.text = $"Rounds left: {remainingRounds}";
        }
        else
        {
            Debug.LogError("roundCounterText is not assigned in the Inspector!");
        }
    }
}
