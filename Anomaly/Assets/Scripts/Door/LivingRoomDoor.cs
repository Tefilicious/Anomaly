using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LivingRoomDoor : MonoBehaviour, IInteractable
{
    public Text text;

    private bool isSolved;
    private float waitTime = 3.0f;
    private Coroutine textCoroutine;

    IEnumerator ShowTextForSeconds(string message, float seconds)
    {
        text.text = message;

        yield return new WaitForSeconds(seconds);
        text.text = string.Empty;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(Collider collider)
    {
        isSolved = BookPuzzleManager.isPuzzleSolved;

        if (isSolved)
        {
            SceneManager.LoadScene(6);
        }
        else
        {
            if (textCoroutine != null)
            {
                StopCoroutine(textCoroutine);
            }
            textCoroutine = StartCoroutine(ShowTextForSeconds("Solve Puzzle First", waitTime));
        }
    }
}
