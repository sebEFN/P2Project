using UnityEngine;

public class SequenceManager : MonoBehaviour
{
    public string[] correctSequence;

    private int currentIndex = 0;

    public void RegisterClick(string objectID)
    {
        // Check if clicked object matches expected sequence item
        if (objectID == correctSequence[currentIndex])
        {
            Debug.Log("Correct!");

            currentIndex++;

            // Sequence complete
            if (currentIndex >= correctSequence.Length)
            {
                Debug.Log("Sequence Completed!");
                currentIndex = 0;
            }
        }
        else
        {
            Debug.Log("Wrong! Resetting sequence.");
            currentIndex = 0;
        }
    }
}
