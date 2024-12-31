using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObj : MonoBehaviour, IInteractable
{
    [SerializeField]
    private string objDescription;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(Text textDisplay)
    {
        textDisplay.text = objDescription;
    }
}
