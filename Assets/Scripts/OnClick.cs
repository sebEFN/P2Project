using UnityEngine;
using UnityEngine.EventSystems;

public class OnClick : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick (PointerEventData eventData)
    {
        Debug.Log ("clicked");
    }
}

