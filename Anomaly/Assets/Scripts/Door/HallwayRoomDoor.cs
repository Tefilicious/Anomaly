using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HallwayRoomDoor : MonoBehaviour, IInteractable
{
    public Text text;

    private bool isCodeCorrect;
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
        isCodeCorrect = UpdateLock.isCodeCorrect;

        if (isCodeCorrect)
        {
            SceneManager.LoadScene(7);
        } else
        {
            if (textCoroutine != null)
            {
                StopCoroutine(textCoroutine);
            }
            textCoroutine = StartCoroutine(ShowTextForSeconds("Door is Locked", waitTime));
        }
    }
}
