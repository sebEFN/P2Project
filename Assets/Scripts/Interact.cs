using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    public GameObject framenow;
    public GameObject nextFrame;
    
    void Start()
    {
    }
    void Update()
    {
        if (GetComponent<OnClick>().isclick == true)
        {
            Debug.Log("meow");
            framenow.SetActive(false);
            nextFrame.SetActive(true);

            GetComponent<OnClick>().isclick = false;

        }
    }
}
    
      


