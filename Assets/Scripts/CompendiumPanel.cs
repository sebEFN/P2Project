using UnityEngine;

public class CompendiumPanel : MonoBehaviour
{
    [SerializeField] GameObject compendiumPanel;
    [SerializeField] Compendium compendium;

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
    
