using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyAppearManager : MonoBehaviour
{
    public GameObject hiddenKey; // Drag and drop the hidden key GameObject here in the Inspector

    void Start()
    {
        // Check if the puzzle in the previous scene was solved
        if (PlayerPrefs.GetInt("PuzzleSolved", 0) == 1) // Default is 0 (not solved)
        {
            if (hiddenKey != null)
            {
                hiddenKey.SetActive(true); // Make the key visible
            }
            else
            {
                Debug.LogError("Hidden key is not assigned in the Inspector!");
            }
        }

    }

}

