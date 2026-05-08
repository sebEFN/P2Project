using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Compendium : MonoBehaviour
{
    public List<Signs> signs = new List<Signs>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
{

        var curObjectScripts = FindObjectsOfType<Compendium>();
        if (curObjectScripts.Count() > 1)
        {
                Destroy(gameObject);
                return;
        }

        DontDestroyOnLoad(gameObject);

}

    // Update is called once per frame
    void Update()
    {
        
    }
}
