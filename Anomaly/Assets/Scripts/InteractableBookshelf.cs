using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class InteractableBookshelf : MonoBehaviour, IInteractable
{
    private bool isPlayerNear = false; // Tracks if the player is in range
    public GameObject interactMessage; // UI element to show interaction message

    private void Start()
    {
        // Hide the interaction message at the start
        if (interactMessage != null)
        {
            interactMessage.SetActive(false);
        }
    }

    private void Update()
    {
        // Check if the player presses "E" while near the bookshelf
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            LoadPuzzleScene();
        }
    }

    private void LoadPuzzleScene()
    {
        // Load the PuzzleGameScene
        SceneManager.LoadScene("PuzzleGameScene");
    }

    public void Interact(Collider collider)
    {
        // This method is called when the player is near the bookshelf
        isPlayerNear = true;

        // Show interaction UI
        if (interactMessage != null)
        {
            interactMessage.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the interaction area
        if (other.CompareTag("Player"))
        {
            Interact(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player exits the interaction area
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;

            // Hide interaction UI
            if (interactMessage != null)
            {
                interactMessage.SetActive(false);
            }
        }
    }
}
