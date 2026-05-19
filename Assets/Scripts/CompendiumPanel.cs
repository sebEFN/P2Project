using UnityEngine;

public class CompendiumPanel : MonoBehaviour
{
    [SerializeField] GameObject compendiumPanel;
    [SerializeField] GetSign compendium;

    public void ToggleCompendium()
    {
        bool isOpen = compendiumPanel.activeSelf;
        compendiumPanel.SetActive(!isOpen);

        if (!isOpen)
        {
            compendium.RefreshUI();
        }
    }
}
    
