using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSelection : MonoBehaviour
{
    public Material glowMaterial; // Glow material
    private Material originalMaterial; // Original material
    private Renderer bookRenderer;
    public string bookName; // Unique name for the book (e.g., A, S, D, F, G)
    private BookPuzzleManager puzzleManager;
    public AudioSource audioSource; // Reference to the AudioSource


    void Start()
    {
        bookRenderer = GetComponent<Renderer>();
        originalMaterial = bookRenderer.material; // Store the original material
        puzzleManager = FindObjectOfType<BookPuzzleManager>();
        audioSource = GetComponent<AudioSource>(); 
    }

    void OnMouseDown() // Trigger when the book is clicked
    {
        SelectBook();
        puzzleManager.BookSelected(bookName); // Notify the puzzle manager
    }

    public void SelectBook()
    {
        StopAllCoroutines(); // Stop any ongoing glow effect
        StartCoroutine(FadeGlowEffect());
        Debug.Log($"Book {bookName} selected!");
        audioSource.Play();
    }

    private IEnumerator FadeGlowEffect()
    {
        // Apply the glow material
        bookRenderer.material = glowMaterial;

        // Gradually increase emission intensity
        float intensity = 0f;
        while (intensity < 1f)
        {
            intensity += Time.deltaTime * 2f; // Adjust speed of fade-in
            glowMaterial.SetColor("_EmissionColor", Color.yellow * intensity);
            yield return null;
        }

        // Gradually decrease emission intensity
        while (intensity > 0f)
        {
            intensity -= Time.deltaTime * 4f; // Adjust speed of fade-out
            glowMaterial.SetColor("_EmissionColor", Color.white * intensity);
            yield return null;
        }

        // Restore the original material
        bookRenderer.material = originalMaterial;
    }
}
