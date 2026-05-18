using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PuzzelSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Signs correctSigns;
    [SerializeField] string nextScene;
    [SerializeField] RawImage SlotImage;

    public static int correctCount = 0;
    private Signs placedSign;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (SignSelector.Instance.selectedSign == null)
            return;
        placedSign = SignSelector.Instance.selectedSign;
        SlotImage.texture = placedSign.signImage;
        SlotImage.color = Color.white;

        SignSelector.Instance.selectedSign = null;

        CheckPuzzle();
    }

    void CheckPuzzle()
    {
        if (placedSign == correctSigns)
        {
            correctCount++;
            Debug.Log("Correct" + correctCount + "/2");
            if (correctCount >= 2)
            {
                correctCount = 0;
                SceneManager.LoadScene(nextScene);
            }
        }
        else
        {
            Debug.Log("Wrong");
            SlotImage.texture = null;
            SlotImage.color = Color.white;
            placedSign = null;
        }
    }
}
