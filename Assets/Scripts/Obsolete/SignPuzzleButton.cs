using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SignPuzzleButton : MonoBehaviour
{
    public Button SignButton;
    void Start()
        {
            Button button = SignButton.GetComponent<Button>();
            button.onClick.AddListener(TaskOnClick);
        }
    
    public void TaskOnClick()
        {
        Debug.Log("You have clicked the button");
        }
 
}
