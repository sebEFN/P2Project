using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;

public class GetSign : MonoBehaviour
{
    [SerializeField] GameObject spawnSign;
    [SerializeField] Transform listContainer;
    //content object of the scroll view, where the signs will be spawned as children
     [SerializeField] Compendium compendium;
    List<GameObject> spawnedCards = new List<GameObject>();
    void Start()
    {
        compendium = GameObject.FindGameObjectWithTag("CompendiumTag").GetComponent<Compendium>();
    }
    public void RefreshUI()
    {
        //spawn one card per sign
        foreach (var item in compendium.signs)
        {
            GameObject currentSign = Instantiate(spawnSign, new Vector2(0, 0), Quaternion.identity);
            currentSign.transform.SetParent(listContainer, false);
            currentSign.name = item.signName;
             RawImage img = currentSign.GetComponent<RawImage>();
            img.texture = item.signImage;
            currentSign.GetComponent<CompendiumCard>().sign = item;
            spawnedCards.Add(currentSign);
        }
    }
}
