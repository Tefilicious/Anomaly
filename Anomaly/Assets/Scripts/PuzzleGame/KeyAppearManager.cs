using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyAppearManager : MonoBehaviour
{
    public static KeyAppearManager Instance { get; private set; }
    public bool IsPuzzleSolved { get; private set; } = false; // Default: not solved
    public GameObject hiddenKey; // Drag and drop the hidden key GameObject here in the Inspector

    void Awake()
    {
        // Ensure this object persists across scenes
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void MarkPuzzleAsSolved()
    {
        IsPuzzleSolved = true;
    }

    void Start()
    {
        // Hide the key at the start of the game
        if (hiddenKey != null)
        {
            hiddenKey.SetActive(false);
        }
    }

    void OnSceneLoaded()
    {
        // Show the key if the puzzle is solved and we're in the Living Room scene
        if (IsPuzzleSolved && hiddenKey != null)
        {
            hiddenKey.SetActive(true);
        }
    }

}

