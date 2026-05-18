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
        if (instance != null && instance != this)
    {
        Destroy(gameObject);
        return;
    }

    instance = this;
    DontDestroyOnLoad(gameObject);
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
            GameObject currentSign = Instantiate(spawnSign, new Vector2(0, 0), Quaternion.identity);
            currentSign.transform.SetParent(listContainer, false);
            currentSign.name = item.signName;
            currentSign.GetComponent<RawImage>().texture = item.signImage;
            currentSign.GetComponent<CompendiumCard>().sign = item;
            spawnedCards.Add(currentSign);
        }
    }
}
