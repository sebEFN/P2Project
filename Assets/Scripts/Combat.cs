using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using JetBrains.Annotations;

public class Combat : MonoBehaviour
{
      public GameObject spawnSign;
      public int health;
      public bool isSleeping = false;

    // An instance of the ScriptableObject defined above.
   [SerializeField] Compendium compendium;

    // This will be appended to the name of the created entities and increment when each is created.
    int instanceNumber = 1;

    void Start()
    {
        SpawnEntities();
    }

    void SpawnEntities()
    {

        foreach(var item in compendium.signs)
        {
            // Creates an instance of the prefab at the current spawn point.
            GameObject currenSign = Instantiate(spawnSign, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            currenSign.transform.SetParent (GameObject.FindGameObjectWithTag("Canvas").transform, false);

            // Sets the name of the instantiated entity to be the string defined in the ScriptableObject and then appends it with a unique number. 
            currenSign.name = item.signName + instanceNumber;
            Image img = currenSign.GetComponent<Image>();
            img.sprite = item.signImage;
            Button signButton = currenSign.GetComponent<Button>();
            signButton.onClick.AddListener(() => ButtonEffects(item));

            instanceNumber++;
        }
    }
    void UpdateHealth()
    {
        health -= 1 ;
    }

    void ButtonEffects(Signs item)
    {
        health -= item.damage;
        isSleeping = item.sleep;
        health += item.healing;
    }
}
