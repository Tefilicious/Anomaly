using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

interface IInteractable
{
    public void Interact(Text textDisplay);
}

public class Interactor : MonoBehaviour
{
    public Transform interactorSource;
    public float interactRange = 5.0f;
    public Text textDescription;
    public GameObject handUI;

    // Start is called before the first frame update
    void Start()
    {
        handUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(interactorSource.position, interactorSource.forward);
        // C# is pass by value thats why the out keyword REMEMBER DAT
        if (Physics.Raycast(ray, out RaycastHit hitInfo, interactRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                handUI.SetActive(true);
                if (Input.GetButtonDown("Interact"))
                {
                    interactObj.Interact(textDescription);
                }
            }
            else 
            { 
                handUI.SetActive(false);
                textDescription.text = "";
            }
        }
        else 
        { 
            handUI.SetActive(false);
            textDescription.text = "";
        }
    }
}
