using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayObjText : MonoBehaviour, IDisplayText
{
    [SerializeField] private string objDescription;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayText(Text textDisplay)
    {
        textDisplay.text = objDescription;
    } 
}
