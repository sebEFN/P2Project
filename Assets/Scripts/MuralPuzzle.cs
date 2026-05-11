using UnityEngine;

public class MuralPuzzle : MonoBehaviour
{
    [Header("Correct Button Order")]
    public string[] correctSequence;

    public GameObject currentcanvas;
    public GameObject nextcanvas;

    public GameObject[] progressSprites;

    private int currentIndex = 0;

    private void Start()
    {
        ResetSprites();
    }
    public void ButtonPressed(string buttonID)
    {
        // Correct button clicked
        if (buttonID == correctSequence[currentIndex])
        {
            Debug.Log("Correct: " + buttonID);

            if (currentIndex < progressSprites.Length)
            {
                progressSprites[currentIndex].SetActive(true);
            }

            currentIndex++;

            // Finished sequence
            if (currentIndex >= correctSequence.Length)
            {
                SequenceComplete();
            }
        }
        else
        {
            Debug.Log("Wrong button. Resetting.");
            ResetSequence();
        }
    }

    private void SequenceComplete()
    {
        currentcanvas.SetActive(false);
        nextcanvas.SetActive(true);
        Debug.Log("SEQUENCE COMPLETE!");

        // Example:
        // OpenDoor();
        // Play animation
        // Enable next puzzle

        ResetSequence();
    }

    private void ResetSequence()
    {
        currentIndex = 0;
        ResetSprites();
    }
    private void ResetSprites()
    {
        foreach (GameObject sprite in progressSprites)
        {
            sprite.SetActive(false);
        }
    }
}
