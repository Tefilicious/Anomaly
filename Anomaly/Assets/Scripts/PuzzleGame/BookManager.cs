using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    public GameObject[] books; // Array to hold book GameObjects
    public Material glowMaterial; // Glow material for highlighting
    public BookPuzzleManager puzzleManager; // Reference to the puzzle manager

    void Update()
    {
        // Check for key presses and highlight the corresponding book
        if (Input.GetKeyDown(KeyCode.A))
            SelectAndHighlightBook(0, "A"); // Book A
        if (Input.GetKeyDown(KeyCode.S))
            SelectAndHighlightBook(1, "S"); // Book S
        if (Input.GetKeyDown(KeyCode.D))
            SelectAndHighlightBook(2, "D"); // Book D
        if (Input.GetKeyDown(KeyCode.F))
            SelectAndHighlightBook(3, "F"); // Book F
        if (Input.GetKeyDown(KeyCode.G))
            SelectAndHighlightBook(4, "G"); // Book G
    }

    void SelectAndHighlightBook(int index, string bookName)
    {
        if (index < 0 || index >= books.Length) return;

        // Highlight the book
        BookSelection book = books[index].GetComponent<BookSelection>();
        if (book != null)
        {
            book.SelectBook(); // Trigger the glow effect
        }

        // Notify the puzzle manager
        if (puzzleManager != null)
        {
            puzzleManager.BookSelected(bookName); // Pass the correct book name
        }
    }
}
