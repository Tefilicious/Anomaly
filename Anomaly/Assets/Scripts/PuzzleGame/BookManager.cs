using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    public GameObject[] books; // Array to hold book GameObjects
    public Material glowMaterial; // Glow material for highlighting

    void Update()
    {
        // Check for key presses and highlight the corresponding book
        if (Input.GetKeyDown(KeyCode.A))
            HighlightBook(0); // Book A
        if (Input.GetKeyDown(KeyCode.S))
            HighlightBook(1); // Book S
        if (Input.GetKeyDown(KeyCode.D))
            HighlightBook(2); // Book D
        if (Input.GetKeyDown(KeyCode.F))
            HighlightBook(3); // Book F
        if (Input.GetKeyDown(KeyCode.G))
            HighlightBook(4); // Book G
    }

    void HighlightBook(int index)
    {
        BookSelection book = books[index].GetComponent<BookSelection>();
        if (book != null)
        {
            book.SelectBook(); // Trigger the glow effect
        }
    }
}
