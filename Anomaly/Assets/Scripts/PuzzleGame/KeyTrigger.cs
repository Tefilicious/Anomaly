using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    public GameObject GrabKey; // Reference to the UI message (TextMeshPro)
    public GameObject ShowKey; // The second key object to show

    // This method is called when another collider enters the trigger area
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player (or another specific object)
        if (other.CompareTag("Player"))  // Ensure the player has the "Player" tag
        {
            // Deactivate the key object (this object that the script is attached to)
            gameObject.SetActive(false); // Hide the key object

            // Deactivate the UI message
            if (GrabKey != null)
            {
                GrabKey.SetActive(false); // Hide the message
            }

            // Show the second key if it's assigned
            if (ShowKey != null)
            {
                ShowKey.SetActive(true); // Make the second key visible
                Debug.Log("Second key revealed!");
            }

            // Optional: Add any other logic, like giving the key to the player
            Debug.Log("Key grabbed and message hidden.");
        }
    }
}
