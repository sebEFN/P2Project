using UnityEngine;

public class Combat : MonoBehaviour
{
    [SerializeField] Compendium mySigns;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var item in mySigns.signs)
        {
            Debug.Log("meow");
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
