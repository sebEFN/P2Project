using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] Signs[] giveSign;
    [SerializeField] Compendium compendium;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
         compendium = GameObject.FindGameObjectWithTag("CompendiumTag").GetComponent<Compendium>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<OnClick>().isclick == true)
        {
            GetComponent<OnClick>().isclick = false;
            //compendium.RefreshUI();
            foreach (var item in giveSign)
            {
                compendium.signs.Add(item);  
            }
            this.enabled = false;
            //Debug.Log("Collected " + giveSign.signName);
        }
    }

    public void tutorial()
    {
 
        
        foreach (var item in giveSign)
        {
            compendium.signs.Add(item);
        }
    }
}
