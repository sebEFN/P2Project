using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class OnClick : MonoBehaviour, IPointerClickHandler
{
    public string scne;
    public bool isclick = false;
    public void SwitchScne()
    {
        SceneManager.LoadScene(scne);
    }
    public virtual void OnPointerClick (PointerEventData eventData)
    {
        isclick = true;
        Debug.Log ("clicked");
        if (scne != "")
        {
            SwitchScne();
        }

    }

    
    
}

