using UnityEngine;

public class MuralPuzzle : MonoBehaviour
{
    [Header("Correct Button Order")]
    public string[] correctSequence;

    public GameObject currentcanvas;
    public GameObject nextcanvas;

    private int currentIndex = 0;
    
    public void ButtonPressed(string buttonID)
    {
        // Correct button clicked
        if (buttonID == correctSequence[currentIndex])
        {
            Debug.Log("Correct: " + buttonID);

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
    }
}
