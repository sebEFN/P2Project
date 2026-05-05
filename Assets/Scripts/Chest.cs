using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] Signs giveSign;
    [SerializeField] Compendium compendium;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<OnClick>().isclick == true)
        {
            GetComponent<OnClick>().isclick = false;
            compendium.signs.Add(giveSign);
            Debug.Log("Collected " + giveSign);
        }
    }
}
