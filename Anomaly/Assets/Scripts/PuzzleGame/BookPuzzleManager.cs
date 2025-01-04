using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class BookPuzzleManager : MonoBehaviour
{
    public GameObject[] books; // Array of book GameObjects
    public string[] correctSequence = { "F", "S", "D", "A", "G" }; // Correct order
    private List<string> playerSequence = new List<string>(); // Tracks player's selections
    public GameObject messageUI; // UI element to show messages
    public TextMeshProUGUI roundCounterText; // UI text to show remaining rounds
    private int remainingRounds = 5; // Total rounds allowed
    public GameObject keyObject; // The key object in the scene
    public GameObject continueButton; // UI Button to continue
    public GameObject HideBookKeys; // Parent GameObject containing the book key texts

    void Start()
    {
        Cursor.visible = true; //Make sure to show the mouse cursor.
        Cursor.lockState = CursorLockMode.None; //Make sure the cursor is not locked to the center.
        ResetPuzzle(); // Initialize the puzzle
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
                HideBookKeys.SetActive(false); // Hide book key texts
                HandleWin(); // Handle winning logic
            }
            else
            {
                remainingRounds--; // Decrement the round counter
                UpdateRoundCounter(); // Update the UI
                if (remainingRounds > 0)
                {
                    Debug.Log("Wrong Combination!");
                    ShowMessage("Wrong Combination. Try again!");
                    Invoke(nameof(HideMessage), 2f); // Hide after 2 seconds
                    Invoke(nameof(ResetPuzzle), 0f); // Wait 2 seconds before resetting
                }
                else
                {
                    Debug.Log("Game Over!");
                    ShowMessage("You lose! Try again");
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
                Debug.Log("Incorrect sequence");
                return false;
            }
        }
        return true;
    }

        private void HandleWin()
    {
         // Activate the key object
        if (keyObject != null)
        {
            keyObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Key object is not assigned in the Inspector!");
        }


        // Delay showing the message and button
        Invoke(nameof(ShowWinUI), 4f);
    }

    private void ShowWinUI()
    {
        ShowMessage("You got the KEY!"); // Show winning message
        if (continueButton != null)
        {
            continueButton.SetActive(true); // Show the continue button
        }
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

     public void LoadLivingRoomScene()
    {
        SceneManager.LoadScene("LivingRoomSceneV2"); // Ensure the scene name matches
    }

   

}
