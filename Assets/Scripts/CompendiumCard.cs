using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CompendiumCard : MonoBehaviour, IPointerClickHandler
{
    public Signs sign;

    public void OnPointerClick(PointerEventData eventData)
    {
        SignSelector.Instance.SelectSign(sign);
    }
}
