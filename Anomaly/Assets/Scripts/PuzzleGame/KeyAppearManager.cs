using UnityEngine;
using UnityEngine.SceneManagement;
public class KeyAppearManager : MonoBehaviour
{
    private static KeyAppearManager instance;

    public static KeyAppearManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("KeyAppearManager instance is missing!");
            }
            return instance;
        }
    }

    private bool puzzleSolved = false; // Tracks whether the puzzle is solved

    void Awake()
    {
        // Ensure only one instance of the manager exists
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject); // Persist across scenes
    }

    public void MarkPuzzleAsSolved()
    {
        puzzleSolved = true;
        Debug.Log("Puzzle solved state saved.");
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "LivingRoomSceneV2" && puzzleSolved)
        {
            // Debugging: Log all objects with the 'HiddenKey' tag
            GameObject[] allObjects = GameObject.FindGameObjectsWithTag("HiddenKey");
            foreach (var obj in allObjects)
            {
                Debug.Log($"Found object with tag 'HiddenKey': {obj.name}");
            }
            // Locate the parent GameObject with the tag "HiddenKey"
            GameObject hiddenKeyParent = GameObject.FindWithTag("HiddenKey");
            if (hiddenKeyParent != null)
            {
                // Activate the child key object
                Transform hiddenKey = hiddenKeyParent.transform.GetChild(0); // Assumes the key is the first child
                if (hiddenKey != null)
                {
                    hiddenKey.gameObject.SetActive(true); // Make the child key object visible
                    Debug.Log($"Key revealed in Living Room. Parent: {hiddenKeyParent.name}, Child: {hiddenKey.name}");
                }
                else
                {
                    Debug.LogError("Hidden key child object not found under the parent!");
                }
                
                // Activate the light (second child in the parent)
                Transform lightObject = hiddenKeyParent.transform.GetChild(1); // Assuming the light is the second child
                if (lightObject != null)
                {
                    lightObject.gameObject.SetActive(true); // Make the light visible
                    Debug.Log("Light revealed in Living Room.");
                }
            }
            else
            {
                Debug.LogError("HiddenKeyParent object not found! Ensure the parent GameObject is tagged as 'HiddenKey'.");
            }
        }
    }


    void OnEnable()
    {
        // Subscribe to the scene loaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Unsubscribe to avoid memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
