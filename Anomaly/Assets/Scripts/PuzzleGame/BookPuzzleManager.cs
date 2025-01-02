using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookPuzzleManager : MonoBehaviour
{
    public GameObject[] books; // Array of book GameObjects
    public string[] correctSequence = { "F", "S", "D", "A", "G" }; // Correct order
    private List<string> playerSequence = new List<string>(); // Tracks player's selections
    public GameObject messageUI; // UI element to show messages

    void Start()
    {
        ResetPuzzle(); // Initialize the puzzle
        messageUI.SetActive(false); // Hide message UI at the start
    }

    public void BookSelected(string bookName)
    {
        playerSequence.Add(bookName); // Add selected book to the sequence

        // Check if player has completed the sequence
        if (playerSequence.Count == correctSequence.Length)
        {
            if (IsCorrectSequence())
            {
                Debug.Log("Puzzle Solved!");
                ShowMessage("You solved the puzzle!");
                // Add logic to unlock the door or proceed to the next stage
            }
            else
            {
                Debug.Log("Incorrect combination. Restarting...");
                ShowMessage("Try again, the Anomaly will find you!");
                Invoke(nameof(ResetPuzzle), 2f); // Wait 2 seconds before resetting
            }
        }
    }

    private bool IsCorrectSequence()
    {
        for (int i = 0; i < correctSequence.Length; i++)
        {
            if (playerSequence[i] != correctSequence[i])
                return false;
        }
        return true;
    }

    private void ResetPuzzle()
    {
        playerSequence.Clear(); // Clear the player's sequence
        Debug.Log("Puzzle Reset. Try again!");
    }

    private void ShowMessage(string text)
    {
        // Assuming a Text component is on the message UI
        messageUI.SetActive(true);
        messageUI.GetComponent<UnityEngine.UI.Text>().text = text;
        Invoke(nameof(HideMessage), 2f); // Hide the message after 2 seconds
    }

    private void HideMessage()
    {
        messageUI.SetActive(false);
    }
}
