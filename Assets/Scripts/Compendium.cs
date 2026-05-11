using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class Compendium : MonoBehaviour
{
    public static Compendium instance;

    public List<Signs> signs = new List<Signs>();

    
    [SerializeField] GameObject spawnSign;
    [SerializeField] Transform listContainer;
    //content object of the scroll view, where the signs will be spawned as children

    List<GameObject> spawnedCards = new List<GameObject>();

    private void Awake()
    {
        if (instance != null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void RefreshUI()
    {
        //clear old cards
        foreach (var card in spawnedCards)
            Destroy(card);

        spawnedCards.Clear();

        //spawn one card per sign
        foreach (var item in signs)
        {
            GameObject currentSign = Instantiate(spawnSign);
            currentSign.transform.SetParent(listContainer, false);
            currentSign.name = item.signName;
            currentSign.GetComponent<Image>().sprite = item.signImage;
            currentSign.GetComponent<CompendiumCard>().sign = item;
            spawnedCards.Add(currentSign);
        }
    }
}
